using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : PhysicsController, IPoolable
{
    private Vector2 startPosition;
    protected Transform bulletRespawn;

    private float speed;
    public int bombRadius;
    public float bombForce;
    //protected override void Awake()
    //{
    //    base.Awake();
    //    Distance = float.MaxValue;
    //}

    public float Speed
    {
        get { return speed; }
        set { 
            speed = value;
            rb.velocity = tf.right * speed;
        }
    }

    public float Distance { get; protected set; }

    public void Init(float speed, float distance)
    {
        this.Speed = speed;
        this.Distance = distance;

        startPosition = tf.position;
    }

    public void Init(float speed, float distance, Vector2 position, Quaternion rotation)
    {
        tf.position = position;
        tf.rotation = rotation;
        Init(speed, distance);

        Debug.Log($"Bullet {speed} {distance} {position} {rotation.eulerAngles.z}");
    }

    public void Recycle()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if(Vector2.Distance(startPosition,tf.position) >= Distance)
        {
            
            SendToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Enemies"));
		    
            foreach(Collider2D en in enemies)
            {
                // Check if it has a rigidbody (since there is only one per enemy, on the parent).
                Rigidbody2D rb = en.GetComponent<Rigidbody2D>();
                if(rb != null && rb.tag == "Enemy")
                {
                    // Find the Enemy script and set the enemy's health to zero.
                    rb.gameObject.GetComponent<EnemyBase>()._HP = 0;

                    // Find a vector from the bomb to the enemy.
                    Vector3 deltaPos = rb.transform.position - transform.position;
                    
                    // Apply a force in this direction with a magnitude of bombForce.
                    Vector3 force = deltaPos.normalized * bombForce;
                    rb.AddForce(force);
                }
            }
            CancelInvoke("Explode");
            Destroy(gameObject);
        
        if(collision.tag == "Enemy")
        {
            SendToPool();
        }
    }

  
    protected void SendToPool()
    {
        Factory.Instance.ReturnObject(FactoryItem.Rocket, this);
    }
}
