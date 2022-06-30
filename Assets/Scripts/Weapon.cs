using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable]
public class Weapon : Item
{
    protected Transform bulletRespawn;

    public WeaponDTO dto;

    public BulletController bulletPrefab;

    public int Damage { get; protected set; }
    public float FireRate { get; protected set; }
    public float ReloadTime { get; protected set; }
    public int AmmoMax { get; protected set; }
    public float Distance { get; protected set; }
    public float Speed { get; protected set; }
    public float Accuracy { get; protected set; }

    private bool isFireRateCooldown;

    

    public bool CanFire 
    { 
        get
        {
            return !isFireRateCooldown;
        } 
    }

    protected override void Awake()
    {
        base.Awake();
        gameObject.tag = "Weapon";
        //bulletPrefab = Resources.Load<BulletController>("Prefabs/Bullet");

        Transform[] children = tf.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            if(child.name == "BulletRespawn")
            {
                bulletRespawn = child;
                break;
            }
        }
    }

    public virtual void Init(WeaponDTO wdto)
    {
        dto = wdto;
        Name = wdto.Name;
        Damage = wdto.Damage;
        FireRate = wdto.FireRate;
        ReloadTime = wdto.ReloadTime;
        AmmoMax = wdto.AmmoMax;
        Distance = wdto.Distance;
        Speed = wdto.Speed;
        Accuracy = wdto.Accuracy;
    }

    IEnumerator FireRateCooldown()
    {
        isFireRateCooldown = true;
        Debug.Log($"{Name} Fire Rate {isFireRateCooldown}");
        yield return new WaitForSeconds(FireRate);
        isFireRateCooldown = false;
        Debug.Log($"{Name} Fire Rate {isFireRateCooldown}");
    }

    public virtual void Fire()
    {
        if(!CanFire)
        {
            return;
        }

        StartCoroutine(FireRateCooldown());

        CreateBullets();
        Debug.Log(this.Damage);
    }

    protected virtual void CreateBullets()
    {
        GameObject go = Factory.Instance.GetObject(FactoryItem.Bullet);
        BulletController bc = go.GetComponent<BulletController>();
        bc.Init(10f, 5f, bulletRespawn.position, bulletRespawn.rotation, this.Damage);
    }

    private void OnEnable()
    {
        Debug.Log($"{Name} enable");
    }
    private void OnDisable()
    {
        Debug.Log($"{Name} Disable");
        isFireRateCooldown = false;
    }
}
