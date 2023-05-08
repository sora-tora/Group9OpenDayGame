using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float lookDelay = 0.5f;
    private float lastLookTime = 0f;

    void Update()
    {
        if (Time.time - lastLookTime > lookDelay)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            lastLookTime = Time.time;
        }
    }
}