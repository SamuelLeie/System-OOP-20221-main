using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Rocket : MonoBehaviour 
{
	public float bombRadius = 10f;
	public float bombForce = 100f;
	
	
	public Transform target;
	
	
	[FormerlySerializedAs("MissileSpeed")] public float missileSpeed;
	private float turn = 2.5f;
	private float lastTurn=0f;
	

	private Rigidbody2D rocketRigidbody;

	void Awake()
	{
		rocketRigidbody=GetComponent<Rigidbody2D>();
	}
	
	void Start(){
		Invoke ("Explode", 5f);
	}

	private void FixedUpdate()
	{
		Quaternion newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turn);
		rocketRigidbody.velocity = transform.up * missileSpeed;
		if (turn < 40f)
		{
			lastTurn += Time.deltaTime * Time.deltaTime * 50f;
			turn += lastTurn;
		}


	}

	private void Explode()
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
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Enemy"))
		{
				Explode ();
		}
	}
}	
