using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    [RequireComponent(typeof(LK_PlayerPickup))]
    public class LK_DropOnCollide : MonoBehaviour
    {
        private LK_PlayerPickup _pickup;
        private LK_MinigameManager _manager;
        private void Awake()
        {
            _pickup  = GetComponent<LK_PlayerPickup>();
            _manager = FindObjectOfType<LK_MinigameManager>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            LK_Obstacle obst = collision.gameObject.GetComponentInParent<LK_Obstacle>();
            if (obst != null)
            {
                GameObject item = _pickup.Hand.TakeItem();
                if (item != null )
                {
                    _manager.Score -= 1;
                }
            }
        }
    }
}