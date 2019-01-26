using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitDonki : MonoBehaviour
{

    public static List<GameObject> donkies = new List<GameObject>();
    public float hitForce = 500f;
    public GameObject target;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShrakSmash();
        }
    }

    void ShrakSmash()
    {
        foreach (GameObject d in donkies)
        {
            Vector3 dir = (target.transform.position - transform.position).normalized;
            d.GetComponent<EnemyAi>().GetHit(dir, hitForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<NavMeshAgent>() != null && !donkies.Contains(other.gameObject))
        {
            donkies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(donkies.Contains(other.gameObject))
        {
            donkies.Remove(other.gameObject);
        }
    }

}
