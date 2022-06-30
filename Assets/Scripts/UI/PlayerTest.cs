using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxAmmo = 20;
    public float reloadT;
    public int currentAmmo;
    public int currentHealth;
    public UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        reloadT = 1;
        currentHealth = maxHealth;
        currentAmmo = maxAmmo;
        //uiManager.SetUpHealth(maxHealth);
        uiManager.SetUpWeapon(maxAmmo, reloadT);
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    currentHealth--;
        //    uiManager.OnTamageTaken(currentHealth);
        //}

        if (Input.GetKeyDown(KeyCode.R) || currentAmmo == 0)
        {
            uiManager.OnWeaponReload();
            currentAmmo = maxAmmo;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentAmmo--;
            uiManager.OnWeaponUsed(currentAmmo);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            uiManager.OnBulletCollisionWithEnemy(gameObject.transform.position, 50);
        }
    }
}
