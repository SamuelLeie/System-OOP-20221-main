using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDTO", menuName = "Resources/DTO/")]
public class EnemyDTO : ScriptableObject
{
    public string ename;
    public int damage;
    public float speed;
    //public int _maxHP;
}
