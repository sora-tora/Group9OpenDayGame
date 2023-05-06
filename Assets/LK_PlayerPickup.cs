using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LK_PlayerPickup : MonoBehaviour
{
    public KeyCode PickupButton = KeyCode.E;

    public float PickupActiveTime = 0.2f;
    private float _pickupActiveT = 0f;

    public LK_ColTrigger PickupTrigger;
    public LK_PlayerHand Hand;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
