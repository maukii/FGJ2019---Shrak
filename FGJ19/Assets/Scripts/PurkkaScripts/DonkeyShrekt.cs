using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyShrekt : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] float radius;
    [SerializeField] float upforce;

    [SerializeField] bool canhit;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canhit = true;
            if (canhit && Input.GetMouseButtonDown(0))
            {
                SkyIsTheLimit();
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

    void SkyIsTheLimit()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, upforce, ForceMode.Impulse);
        }
    }
}