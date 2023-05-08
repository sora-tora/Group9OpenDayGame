using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    public class LK_Obstacle : MonoBehaviour
    {
        public float MaxX = 10f;
        public float PauseTime = 10f;
        public float Speed = 3f;

        private bool _goRight = true;
        private float _wait_t = 0f;

        private void Update()
        {
            if (_wait_t <= 0)
            {
                transform.position += (_goRight ? Vector3.right : Vector3.left) * Speed * Time.deltaTime;
                if (Mathf.Abs(transform.position.x) > MaxX)
                {
                    _wait_t = PauseTime;
                    _goRight = !_goRight;
                }
            }
            else
            {
                _wait_t -= Time.deltaTime;
            }
        }
    }
}