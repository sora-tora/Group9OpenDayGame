using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner_Script : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject obstacle;

    public float fireRate = 3000f; 

    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            spawnTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Instantiate(obstacle,spawnPoint.position,transform.rotation);
        }
    }
}
