using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDTO", menuName = "DTO")]
public class EnemyDTO : ScriptableObject
{
    public string name;
    public int damage;
    public int _HP;
    public float speed;
    public int _maxHP;
}
