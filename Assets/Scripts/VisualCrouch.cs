using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCrouch : MonoBehaviour
{
    private Player_Controller playerCon;
    public SpriteRenderer playerSprite;
    public SpriteRenderer crouchPoint;
    public Sprite crouch;
    public Sprite stand;

    void Awake()
    {
        playerCon = this.GetComponent<Player_Controller>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!playerCon.isCrouching)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            playerSprite.sprite = stand;
        }

        if(playerCon.isCrouching)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            crouchPoint.sprite = crouch;
        }
    }
}
