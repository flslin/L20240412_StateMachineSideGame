using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private GameObject enemyPrefabs;

    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (enemyPrefabs != null)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemyPrefabs);
            }
                Invoke("Spawn", 1);
        }
    }
}
