using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyObjectPool;
    [SerializeField] float spawnTimer = 1f;
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    
    IEnumerator spawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
