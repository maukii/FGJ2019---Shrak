using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class HitDonki : MonoBehaviour
{

    AudioSource source;
    public AudioClip aargh;
    public Animator anim;

    public static List<GameObject> donkies = new List<GameObject>();
    public float hitForce = 500f;
    public GameObject target;

    float cooldown = 1f;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = aargh;
    }

    private void Update()
    {
        

        if(cooldown <= 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ShrakSmash();
                cooldown = 1f;
                anim.SetTrigger("Hit");
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    void ShrakSmash()
    {
        source.pitch = 1 + UnityEngine.Random.Range(-0.3f, 0.3f); 
        source.PlayOneShot(aargh);

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
