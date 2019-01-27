using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shout : MonoBehaviour
{
    AudioSource source;
    public AudioClip mene;

    public GameObject shoutPrefab;
    public GameObject shoutE;
    public GameObject shoutD;

    public float shoutCooldown = 5f;
    float timer;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = mene;
    }

    private void Update()
    {
        if(timer < 0)
        {
            shoutD.SetActive(false);
            shoutE.SetActive(true);
            if (Input.GetMouseButtonDown(1))
            {
                shoutE.SetActive(false);
                shoutD.SetActive(true);
                Rawr();
                timer = shoutCooldown;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

    private void Rawr()
    {
        source.pitch = 1 + UnityEngine.Random.Range(-0.3f, 0.3f);
        source.PlayOneShot(mene);
        GameObject bullet = Instantiate(shoutPrefab, transform.position, Camera.main.transform.rotation);
        bullet.GetComponentInChildren<ShoutBullet>().direction = Camera.main.transform.InverseTransformDirection(Camera.main.transform.forward);
    }
}
