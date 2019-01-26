using UnityEngine;

public class MuhDestroy : MonoBehaviour
{
    private float rotateSpeed = 8f;
    private MuhPickups SystemCall;
    public Transform MySpawnPoint;

    void Start()
    {
        SystemCall = GameObject.Find("Pickup_system").GetComponent<MuhPickups>();
    }

    void Update()
    {
        transform.Rotate(0,1,0 * Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerDestroy();
        }
    }

    void PlayerDestroy()
    {
        for (int spawnPoint = 0; spawnPoint < SystemCall.spawnPoints.Length; spawnPoint++)
        {
            if (SystemCall.spawnPoints[spawnPoint] == MySpawnPoint)
            {
                SystemCall.possibleSpawns.Add(SystemCall.spawnPoints[spawnPoint]);
            }
        }
        Destroy(gameObject);
    }
}