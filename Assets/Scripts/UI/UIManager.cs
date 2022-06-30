using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //OBJECTS
    public GameObject mainCanvas;
    public HealthBar healthBar;
    public ReloadIcon reloadIcon;
    public AmmoBar ammoBar;
    public GameObject prefabFloatingDMG;
    public GameObject prefabEnemyHPBar;

    //VARIAVEIS
    public float currentWeaponReloadTime;
    public bool isReloading;
    public int MaxAmmo;



    private void Awake()
    {
        SetUpUI();
        SetUPEnemyUI();
    }

    private void SetUpUI()
    {
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        healthBar = mainCanvas.GetComponentInChildren<HealthBar>();
        reloadIcon = mainCanvas.GetComponentInChildren<ReloadIcon>();
        ammoBar = mainCanvas.GetComponentInChildren<AmmoBar>();
    }

    public void SetUPEnemyUI()
    {
        prefabFloatingDMG = Resources.Load<GameObject>("Prefabs/UIPrefabs/FloatingObject");
        prefabEnemyHPBar = Resources.Load<GameObject>("Prefabs/UIPrefabs/EnemyHealthBar");
    }

    //CHAMAR TODA VEZ QUE UMA NOVA ARMA ENTRA EM JOGO (COMEÇO E TROCAS DE ARMAS) - SETA MUNIÇÃO MAXIMA
    public void SetUpWeapon(int maxAmmo, float reloadTime)
    {
        ammoBar.SetMaxAmmo(maxAmmo);
        MaxAmmo = maxAmmo;
        currentWeaponReloadTime = reloadTime;
        isReloading = false;
    }

    //CHAMAR QUANDO O PLAYER É INSTANCIADO - SETA VIDA MAXIMA PARA BARRA DE VIDA
    public void SetUpHealth(int maxHealth)
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void SetUpEnemyHealth(HealthBar EnemyhealthBar, int maxHealth)
    {
        EnemyhealthBar.SetMaxHealth(maxHealth);
    }

    //CHAMAR QUANDO INIMIGO LEVA DANO PELOS TIROS - CRIA DANOS FLUTUANTES
    public void OnBulletCollisionWithEnemy(Vector2 position, int dmgValue)
    {
        GameObject floatingObj = Instantiate(prefabFloatingDMG, position, Quaternion.identity);
        floatingObj.GetComponent<FloatingDamage>().SetDamageValue(dmgValue);
    }

    //CHAMAR QUANDO ARMA FOR RECARREGAR - ICONE DO COOLDOWN ATIVA E DEPOIS DO TEMPO, MUNIÇÃO RESTAURA NO HUD
    public void OnWeaponReload()
    {
        if(!isReloading)
        {
            reloadIcon.StartReload(currentWeaponReloadTime);
            StartCoroutine(Reloading(currentWeaponReloadTime));
        }
    }

    //CORROTINA PARA RECARREGAR ARMA
    IEnumerator Reloading(float time)
    {
        isReloading = true;
        yield return new WaitForSeconds(time);
        SetUpWeapon(MaxAmmo, time);
    }

    //CHAMAR QUANDO PLAYER LEVAR DANO - DIMINUI VIDA DO HUD
    public void OnTamageTaken(int currentHealth)
    {
        healthBar.SetHealth(currentHealth);
    }

    //CHAMAR QUANDO DISPAROS FOREM EFETUADOS - DIMINUI MUNIÇÃO DO HUD
    public void OnWeaponUsed(int currentAmmo)
    {
        ammoBar.SetAmmo(currentAmmo);
    }

    //CHAMAR QUANDO INIMIGO FOR INSTANCIADO - CRIA BARRA DE VIDA NELE
    public void SetUpEnemyHealth(GameObject enemy, int enemyMaxHealth)
    {
        GameObject ememyHpGO = Instantiate(prefabEnemyHPBar, enemy.transform.position, Quaternion.identity, enemy.transform);
        HealthBar enemyHPBar = ememyHpGO.GetComponentInChildren<HealthBar>();
        enemyHPBar.SetMaxHealth(enemyMaxHealth);
    }

    //CHAMAR QUANDO INIMIGO LEVAR DANO - ATUALIZA BARRA DE VIDA DELE
    public void OnEnemyDamaged(GameObject enemy, int enemyCurrentHealth)
    {
        //HealthBar enemyHPBar = enemy.transform.GetChild(0).GetComponentInChildren<HealthBar>();
        HealthBar enemyHPBar = enemy.GetComponentInChildren<HealthBar>();
        SetUpEnemyHealth(enemyHPBar, enemyCurrentHealth);

    }
}
