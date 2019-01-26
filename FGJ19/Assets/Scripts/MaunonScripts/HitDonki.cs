using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitDonki : MonoBehaviour
{

    public static List<GameObject> donkies = new List<GameObject>();
    public float hitForce = 1000f;

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
            d.GetComponent<NavMeshAgent>().enabled = false;
            Rigidbody r = d.GetComponent<Rigidbody>();
            Vector3 dir = (d.transform.position - transform.position).normalized;
            d.GetComponent<EnemyAi>().beenHit = true;
            StartCoroutine(Smash(r, dir));
        }
    }

    IEnumerator Smash(Rigidbody r, Vector3 dir)
    {
        for (int i = 0; i < 3; i++)
        {
            r.AddForce(dir * hitForce);
            yield return null;
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
