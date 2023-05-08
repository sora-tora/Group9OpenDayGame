using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Satart is called before the first frame update
    Vector3 target;
    float speed = 2.0f;


    void Start()
    {
        setNewTarget(new Vector3(transform.position.x +10, transform.position.y, transform.position.z + 10));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (direction != Vector3.zero)
        {
            setNewTarget(transform.position + direction.normalized);
        }
        transform.Translate((target - transform.position).normalized * speed * Time.deltaTime, Space.World);
    }

    void setNewTarget(Vector3 newTarget)
    {
        target = newTarget;
        transform.LookAt(target);
    }
}