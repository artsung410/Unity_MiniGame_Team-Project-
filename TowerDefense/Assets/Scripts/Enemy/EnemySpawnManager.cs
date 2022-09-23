using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private float SpawnTime;

    private void Start()
    {
        StartCoroutine(EnmeySpawn());
    }

    IEnumerator EnmeySpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnTime);
            Enemy spawnEnemy = EnemyPool.GetObject();
            spawnEnemy.transform.position = transform.position;
        }
    }
}
