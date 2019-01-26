﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public float timeBetweenSpawns = 6f;
    public Transform target;
    public Text timerText;
    public Text winnerText;
    private float time = 180f;
    private bool wiineri = false;

    float timer;

    void Start()
    {
        StartCoundownTimer();
    }

    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            time = 180f;
            timerText.text = "Survive: 03:00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            timerText.text = "Survive: " + minutes + ":" + seconds;
        }
    }

    //time and timer, what could go wrong?
    private void Update()
    {
        timer -= Time.deltaTime;

        if (time < 140)
        {
            timeBetweenSpawns = 5f;
        }

        if (time < 100)
        {
            timeBetweenSpawns = 4f;
        }

        if (time < 60)
        {
            timeBetweenSpawns = 3f;
        }

        if (time < 20)
        {
            timeBetweenSpawns = 2f;
        }

        if (time <= 0)
        {
            timerText.enabled = false;
            foreach (GameObject g in HitDonki.donkies)
            {
                g.GetComponent<EnemyAi>().GetHit(Vector3.zero, 0);
            }
        }

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

        if (time < 140)
        {
            tempEnemy.GetComponent<NavMeshAgent>().speed = 6f;
        }
        if (time < 100)
        {
            tempEnemy.GetComponent<NavMeshAgent>().speed = 7f;
        }
        if (time < 60)
        {
            tempEnemy.GetComponent<NavMeshAgent>().speed = 8f;
        }
        if (time < 20)
        {
            tempEnemy.GetComponent<NavMeshAgent>().speed = 10f;
        }
    }
}
