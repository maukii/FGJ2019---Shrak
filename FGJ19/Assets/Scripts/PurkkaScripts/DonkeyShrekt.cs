using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DonkeyShrekt : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] float radius;
    [SerializeField] float upforce;

    [SerializeField] bool canhit;

    NavMeshAgent navAgent;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canhit = true;
            if (canhit && Input.GetMouseButtonDown(0))
            {
                navAgent.enabled = false;
                StartCoroutine(SkyIsTheLimit());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canhit = false;
        }
    }

    IEnumerator SkyIsTheLimit()
    {
        Vector3 pos = transform.position + UnityEngine.Random.insideUnitSphere;

        yield return new WaitForSeconds(0.02f);
        //Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(pos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, pos, radius, upforce, ForceMode.Impulse);
            }
        }
    }
}