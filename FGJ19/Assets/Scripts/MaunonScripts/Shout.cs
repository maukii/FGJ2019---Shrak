using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shout : MonoBehaviour
{

    public GameObject shoutPrefab;
    public GameObject shoutE;
    public GameObject shoutD;

    public float shoutCooldown = 5f;
    float timer;

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
        GameObject bullet = Instantiate(shoutPrefab, transform.position, Camera.main.transform.rotation);
        bullet.GetComponentInChildren<ShoutBullet>().direction = Camera.main.transform.InverseTransformDirection(Camera.main.transform.forward);
    }
}
