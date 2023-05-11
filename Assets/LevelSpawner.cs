using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject[] Obstacles;
    public float Frequency = 1.5f;

    private float _t = 0f;
    private float _random = 0f;

    // Update is called once per frame
    void Update()
    {
        _t += Time.deltaTime;
        if (_t > Frequency + _random)
        {
            _t = 0f;
            _random = Random.Range(-0.5f, 0.2f);
            GameObject newObj = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)]);
            newObj.transform.position = SpawnPoint.position;
        }
    }
}
