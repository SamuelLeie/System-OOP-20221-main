using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Weapon
{
    public int bombRadius { get; protected set; }
    public float bombForce { get; protected set; }

    public override void Init(WeaponDTO wdto)
    {
        base.Init(wdto);

        BazookaDTO sdto = wdto as BazookaDTO;
        bombRadius = sdto.bombRadius;
        bombForce = sdto.bombForce;
    }
   
    protected override void CreateBullets()
    {
        GameObject go = Factory.Instance.GetObject(FactoryItem.Rocket);
        RocketController rc = go.GetComponent<RocketController>();
        rc.Init(10f, 5f, bulletRespawn.position, bulletRespawn.rotation);
        
    }
}
