using System.Collections.Generic;
using UnityEngine;

public class MuhPickups : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] pickups;
    public float spawnTime = 1.5f;
    public List<Transform> possibleSpawns = new List<Transform>();

    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            possibleSpawns.Add(spawnPoints[i]);
        }

        InvokeRepeating("SpawnItems", spawnTime, spawnTime);
    }

    void SpawnItems()
    {
        if (possibleSpawns.Count > 0)
        {
            int spawnIndex = Random.Range(0, possibleSpawns.Count);
            int spawnObject = Random.Range(0, pickups.Length);

            GameObject NewPickup = Instantiate(pickups[spawnObject], possibleSpawns[spawnIndex].position, possibleSpawns[spawnIndex].rotation) as GameObject;
            NewPickup.GetComponent<MuhDestroy>().MySpawnPoint = possibleSpawns[spawnIndex];

            possibleSpawns.RemoveAt(spawnIndex);
        }
    }
}