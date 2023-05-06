using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles player movement
/// </summary>
public class LK_TopDownPlayerController : MonoBehaviour
{
    public KeyCode MoveUpKey = KeyCode.W;
    public KeyCode MoveDownKey = KeyCode.S;
    public KeyCode MoveLeftKey = KeyCode.A;
    public KeyCode MoveRightKey = KeyCode.D;

    public float MoveSpeed = 4f;
    public float RunMultiplier = 1.6f;

    // Update is called once per frame
    void Update()
    {
        Vector2 inputs = Vector2.zero;
        float multiply = 1f;
        if (Input.GetKey(MoveUpKey))
            inputs.y = 1;
        else if (Input.GetKey(MoveDownKey))
            inputs.y = -1;
        if (Input.GetKey(MoveRightKey))
            inputs.x = 1;
        else if (Input.GetKey(MoveLeftKey))
            inputs.x = -1;

        if (Input.GetKey(KeyCode.LeftShift))
            multiply = RunMultiplier;

        Vector2 move = inputs * MoveSpeed * multiply * Time.deltaTime;
        transform.position += new Vector3(move.x, move.y);
    }
}
