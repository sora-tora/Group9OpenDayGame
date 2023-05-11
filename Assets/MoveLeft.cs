using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public const float MOVE_SPEED = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * MOVE_SPEED * Time.deltaTime;
    }
}
