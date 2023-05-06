using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    public class LK_PlayerPickup : MonoBehaviour
    {
        public KeyCode PickupButton = KeyCode.E;
        public KeyCode DropButton = KeyCode.Q;

        public float PickupActiveTime = 0.2f;
        private float _pickupActiveT = 0f;

        public LK_ColTrigger PickupTrigger;
        public LK_PlayerHand Hand;
        private LK_MinigameManager _minigameManager;

        private void Awake()
        {
            _minigameManager = FindObjectOfType<LK_MinigameManager>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(DropButton))
            {
                if (Hand.IsHoldingItem())
                {
                    bool isNearRecip = false;
                    LK_ItemRecipient recipient = null;
                    Collider2D[] cols = PickupTrigger.Colliders.ToArray();
                    foreach(Collider2D col2d in cols)
                    {
                        recipient = col2d.gameObject.GetComponent<LK_ItemRecipient>();
                        if (recipient != null)
                        {
                            isNearRecip = true;
                            break;
                        }
                    }
                    if (isNearRecip)
                    {
                        int scoreVal = recipient.GiveItem(Hand.TakeItem());
                        _minigameManager.Score += scoreVal;
                        Debug.Log($"Awarding {scoreVal}");
                    }
                    else
                    {
                        Hand.TakeItem();
                    }
                }
                else
                {
                    Debug.Log("Not holding anything to drop");
                }
            }
            if (Input.GetKeyDown(PickupButton))
            {
                _pickupActiveT = PickupActiveTime;
            }
            if (_pickupActiveT > 0f)
            {
                _pickupActiveT -= Time.deltaTime;
                GameObject p = PickupTrigger.GetClosest();
                if (p != null)
                {
                    // picking up closest item
                    Debug.Log($"Picking up {p.name}");
                    _pickupActiveT = 0;
                    Hand.GiveItem(p);
                }
            }
            else
            {
                //PickupCollider.enabled = false;
            }
        }
    }
}