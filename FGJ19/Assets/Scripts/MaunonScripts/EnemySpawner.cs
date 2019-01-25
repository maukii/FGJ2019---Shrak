using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public float timer;

    float timeBetweenSpawns = 5f;

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnEnemy();
            timer = timeBetweenSpawns;
        }
    }

    private void SpawnEnemy()
    {
        int index = UnityEngine.Random.Range(0, spawnPositions.Length);
        Vector3 spawnPosition = spawnPositions[index].transform.position;
        GameObject tempEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        tempEnemy.transform.parent = transform;
    }
}
