using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class ShoutBullet : MonoBehaviour
{

    Rigidbody rb;

    public float lifetime = 2f;
    public float bulletSpeed = 10f;
    public Vector3 direction;

    public float explodionRadius = 3f;
    public float explosionForce = 500f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 dir = (other.transform.position - transform.position).normalized;

        if (other.gameObject.GetComponent<NavMeshAgent>() != null)
        {
            other.GetComponent<EnemyAi>().GetHit(dir, explosionForce);
        }
        else
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, explodionRadius);
            foreach (Collider c in hits)
            {
                if(c.GetComponent<EnemyAi>() != null)
                {
                    c.GetComponent<EnemyAi>().GetHit(dir, explosionForce);
                }
            }
        }
    }

}
