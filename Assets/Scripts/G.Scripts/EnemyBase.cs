using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemyBase : PhysicsController , IPoolable
{
    public float spawnCD { get; protected set; }
    public string ename { get; protected set; }
    
    [SerializeField]
    

    public int _HP = 100;

    protected int hpMax = 100;

    public Color color0;

    public Color color1;
    public float speed { get; protected set;}
    public int damage { get;  protected set; }
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected Transform pTrans;
    PlayerController pC;
    protected SpriteRenderer enemyRender;
    protected Vector2 initialPos;
    public UIManager manager;
    public EnemyDTO edto;

    protected override void Awake()
    {
        base.Awake();
        spawnCD = 5f;
        player = GameObject.FindGameObjectWithTag("Player");
        pTrans = player.GetComponent<Transform>();
        pC = player.GetComponent<PlayerController>();
        InitDto(edto);
        gameObject.tag = "Enemy";
        rb.freezeRotation = true;
        //Debug.Log(_HP);
        enemyRender = GetComponent<SpriteRenderer>();
        manager = FindObjectOfType<UIManager>();
        manager.SetUPEnemyUI();
        manager.SetUpEnemyHealth(gameObject, _HP);
    }
    private void Update()
    {
        enemyRender.color = Color.Lerp(color0, color1, (float) _HP / hpMax);
    }

    protected virtual void LateUpdate()
    {
        //FollowPlayer();
        //InputDamage();
    }
    public virtual void TakeDamage (int pDamage)
    {
        //recebe o damage do player e desconta do HP
        _HP = _HP - pDamage;
        //manager.OnEnemyDamaged(this.gameObject, _HP);
        //Debug.Log(_HP);
        Death();
    }   
    public virtual void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, pTrans.position, speed * Time.deltaTime);
        
        //faz a diferença entre a posição do inimigo e do player, e passa a posição atual do inimigo, com uma 
        //soma da diferença de posições para seguir o player. Precisa do time.deltatime senão buga. 
    }
    //nota pra mim mesmo - Como usar DTO: criar um DTO no código, criar variáveis dentro dentro, e criar um método
    //inicializante pro dto, onde vamos passar um dto como parâmetro, e as variáveis que nele estão serão passadas para
    //as variáveis do código. Iniciar ele no método Awake, passando como parâmetro a referência de dto criada.
    public virtual void InitDto(EnemyDTO dto)
    {
        this.name = dto.name;
        //this._HP = dto._HP;
        //this._maxHP = dto._maxHP;
        this.speed = dto.speed;
        this.damage = dto.damage;
    }

    public virtual void TurnOn()
    {
        _HP = 100;
        gameObject.SetActive(true);
    }

    public virtual void Recycle()
    {
        gameObject.SetActive(false);
    }

    protected virtual void SendToPool()
    {
        Factory.Instance.ReturnObject(FactoryItem.SquareEnemy, this);
    }

    public void init(Vector2 position, Quaternion rotation)
    {
        tf.position = position;
        tf.rotation = rotation;
        //this._HP = hp;
        //initialPos = tf.position;
        //init(speed);
    }
    
     protected virtual void Death()
     {
         if(_HP <= 0)
         {
            SendToPool();
         }
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            pC.TakeDamage(this.damage);
            SendToPool();
        }
    }
    

    //private void InputDamage()
    //{
    //    if (InputState.FireButton == true)
    //    {
    //        TakeDamage(10);
    //        Debug.Log("EnemyDamage");
    //    }
    //}
}
