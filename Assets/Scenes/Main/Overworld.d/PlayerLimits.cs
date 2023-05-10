using UnityEngine;

namespace Game.Overworld
{
    public class PlayerLimits : MonoBehaviour
    {
        public float LimitX = 10f;
        public float LimitY = 10f;

        private void Update()
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, -LimitX, LimitX);
            pos.y = Mathf.Clamp(pos.y, -LimitY, LimitY);
            transform.position = pos;
        }
    }
}