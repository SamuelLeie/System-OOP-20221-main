using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Item item;
    public Weapon weapon;

    private InputController ic;

    //--------------------------------

    private EnemyBase enB;

    private bool isSpawnCooldown;
    public bool canSpawn
    {
        get
        {
            return !isSpawnCooldown;
        }
    }
    private float spawnCD = 3f;


    private static int height = 25;
    private static int width = 25;

    public GameObject Spawner;
    GameObject enGo;
    [SerializeField]
    //public static SpawnerScript[,] spawnMatriz = new SpawnerScript[width, height];
    //public static Transform[,] spawnPos = new Transform[width,height];
    public static List<Transform> spawnerPositions = new List<Transform>();
    private void Awake()
    {
        enGo = Resources.Load<GameObject>("Prefabs/SquareEnemy");
        enB = enGo.GetComponent<EnemyBase>();
        ic = gameObject.AddComponent<InputController>();
        Spawner = Resources.Load<GameObject>("Prefabs/Spawner");
        SpawnerScript sps = Spawner.GetComponent<SpawnerScript>();
        CreateSpawners(width, height , sps);
        StartCoroutine(SpawnCD());
    }

    private void CreateSpawners(int x, int y, SpawnerScript sp)
    {
        for (int i = -20; i < width; i += 5)
        {
            for (int ii = -20; ii < height; ii += 5)
            {
                Vector3 spawnPos = new Vector3(i, ii, 0);
                GameObject go = GameObject.Instantiate(Spawner,spawnPos, Quaternion.identity);
                spawnerPositions.Add(go.transform);
            }
            
        }
    }
    private IEnumerator SpawnCD()
    {

        yield return new WaitForSeconds(spawnCD);
        EnemySpawn();
        StartCoroutine(SpawnCD());
    }
    private void EnemySpawn()
    {
        int RandPoint = Random.Range(0, GameController.spawnerPositions.Count);
        Transform tftes = GameController.spawnerPositions[RandPoint];

        GameObject go = Factory.Instance.GetObject(FactoryItem.SquareEnemy);
        EnemyBase enB = go.GetComponent<EnemyBase>();
        enB.init(tftes.transform.position, tftes.transform.rotation);
        Debug.Log("Inimigo Spawnado");
    }

    
    /**
     * Enemies
     * Level Design
     * Ammo
     * Reload
     * Pick Ups
     * Player HP
     * Hud
     * Integração
     */
}
