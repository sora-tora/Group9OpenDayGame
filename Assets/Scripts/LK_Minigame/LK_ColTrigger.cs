using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class LK_ColTrigger : MonoBehaviour
    {
        public List<Collider2D> Colliders = new List<Collider2D>();
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!Colliders.Contains(collision)) { Colliders.Add(collision); };
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Colliders.Remove(collision);
        }

        public GameObject GetClosest()
        {
            GameObject closest = null;
            float closestDistance = 1000f;
            foreach (Collider2D col in Colliders)
            {
                if (col.gameObject.GetComponent<LK_Item>() != null)
                {
                    float dist = Vector3.Distance(transform.position, col.transform.position);
                    if (dist < closestDistance)
                        closest = col.gameObject;
                }
            }
            return closest;
        }
    }
}