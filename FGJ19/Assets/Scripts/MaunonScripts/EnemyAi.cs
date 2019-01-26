using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    Rigidbody rb;
    NavMeshAgent agent;
    public bool beenHit = false;
    public float timeBeforeBoom = 1f;

    float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        GameObject target = GameObject.FindGameObjectWithTag("Door").gameObject;
        agent.destination = target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            agent.enabled = false;
        }
    }

    public void GetHit(Vector3 dir, float hitforce)
    {

    }
}
