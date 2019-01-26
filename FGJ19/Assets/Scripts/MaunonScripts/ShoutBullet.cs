using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShoutBullet : MonoBehaviour
{

    public float lifetime = 2f;
    public float bulletSpeed = 10f;
    public Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<NavMeshAgent>() != null)
        {
            HitDonki.donkies.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }

}
