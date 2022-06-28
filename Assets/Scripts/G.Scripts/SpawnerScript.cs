using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    protected GameObject enPrefab;
    private int width = 10;
    private int height = 10;
    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform> ();
    private void Awake()
    {
        enPrefab = Resources.Load<GameObject>("Prefabs/SquareEnemy");
        //CreateSpawners(width, height);
    }

    private void CreateSpawners(int x, int y)
    {
        for (int i = -10; i < width; i += 5)
        {
            for (int ii = -10; ii < height; ii += 5)
            {
                Vector3 spawnPos = new Vector3(i, ii, 0);
                GameObject go = GameObject.Instantiate(this.gameObject, spawnPos, Quaternion.identity);
                spawnPoints.Add(go.transform);
            }

        }
    }

    private void SpawnEnemy()
    {
        int randPoint = Random.Range(0, spawnPoints.Count);
    }
}
