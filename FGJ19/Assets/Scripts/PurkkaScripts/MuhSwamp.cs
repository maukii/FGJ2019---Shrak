using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MuhSwamp : MonoBehaviour
{
    [SerializeField] Slider muhEnergy;
    [SerializeField] bool canHit;
    [SerializeField] float timeToHit = 1.5f;
    public GameObject Lose;
    public GameObject time;

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
                timeToHit = 1.5f;
                muhEnergy.value -= 1;
                GetComponent<BoxCollider>().enabled = true;
                canHit = false;
            }
        }
        if (muhEnergy.value <= 0)
        {
            Lose.SetActive(true);
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
