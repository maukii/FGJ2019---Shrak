using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MuhSwamp : MonoBehaviour
{
    [SerializeField] Slider muhEnergy;
    [SerializeField] bool canHit;
    [SerializeField] float timeToHit = 3f;

    void Start()
    {
        muhEnergy.value = 10;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<NavMeshAgent>() != null)
        {
            canHit = true;
        }
    }

    private void Update()
    {
        if (canHit)
        {
            if (timeToHit >= 0)
            {
                timeToHit -= Time.deltaTime;
            }

            if (timeToHit <= 0)
            {
                timeToHit = 3f;
                muhEnergy.value -= 1;
                GetComponent<BoxCollider>().enabled = true;
                canHit = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<NavMeshAgent>() == null || other.gameObject.GetComponent<NavMeshAgent>() != null)
        {
            canHit = false;
            timeToHit = 3f;
        }
    }
}
