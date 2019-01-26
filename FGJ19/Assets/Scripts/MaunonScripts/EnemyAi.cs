using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    NavMeshAgent agent;
    public bool beenHit = false;
    public float timeBeforeBoom = 1f;

    float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject target = GameObject.FindGameObjectWithTag("Goal").gameObject;
        agent.destination = target.transform.position;
    }

    private void Update()
    {
        if(beenHit)
        {
            timeBeforeBoom -= Time.deltaTime;
            if(timeBeforeBoom <= 0)
            {
                Debug.Log("BOOM");
                HitDonki.donkies.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
