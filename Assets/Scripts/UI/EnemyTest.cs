using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public UIManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        manager.SetUpEnemyHealth(gameObject, maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth--;
            manager.OnEnemyDamaged(gameObject, currentHealth);
        }
    }
}
