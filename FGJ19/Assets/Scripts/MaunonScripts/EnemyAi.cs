using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    public GameObject explosionParticles;

    Rigidbody rb;
    NavMeshAgent agent;
    public bool beenHit = false;
    public float timeBeforeBoom = 1f;
    public float rotMultiplier = 100f;

    float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        GameObject target = GameObject.FindGameObjectWithTag("Door").gameObject;
        agent.destination = target.transform.position;
    }

    private void Update()
    {
        if(beenHit)
        {
            transform.Rotate(Time.deltaTime * (1 + Random.value) * rotMultiplier, Time.deltaTime * (1 + Random.value) * rotMultiplier, Time.deltaTime * (1 + Random.value) * rotMultiplier);
        }
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
        agent.enabled = false;
        rb.isKinematic = false;
        beenHit = true;

        StartCoroutine(Hit(dir, hitforce));
    }

    IEnumerator Hit(Vector3 dir, float hitforce)
    {
        yield return null;

        for (int i = 0; i < 3; i++)
        {
            rb.AddForce(dir * hitforce);
        }

        Destroy(gameObject, timeBeforeBoom);

    }

    private void OnDisable()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);

        if(HitDonki.donkies.Contains(gameObject))
        {
            HitDonki.donkies.Remove(gameObject);
        }
    }

}
