using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header ("Speed Settings")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpSpeed = 9;
    private Rigidbody2D body;
    private CapsuleCollider2D playerCollider;
    private bool grounded;

    [Header ("Crouch Settings")]
    private float crouchHeightPerc = 0.5f;
    [HideInInspector]
    public bool isCrouching;

    private Vector2 standColliderSize;
    private Vector2 standColliderOffset;

    private Vector2 crouchColliderSize;
    private Vector2 crouchColliderOffset;

    float hValue;

    public int health = 100;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();

        standColliderSize = playerCollider.size;
        standColliderOffset = playerCollider.offset;

        crouchColliderSize = new Vector2(standColliderSize.x, standColliderSize.y*crouchHeightPerc);
        crouchColliderOffset = new Vector2(standColliderOffset.x, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Stand();
        Crouch();
    }

    void Movement()
    {
        hValue = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(hValue * speed, body.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && (grounded))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            grounded = false;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerCollider.size = crouchColliderSize;
            playerCollider.offset = crouchColliderOffset;
            isCrouching = true;
        }
    }

    void Stand()
    {
        if (Input.GetKeyUp(KeyCode.S) && (isCrouching))
        {
            playerCollider.size = standColliderSize;
            playerCollider.offset = standColliderOffset;
            isCrouching = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        grounded = true;
    }    
    
    void FixedUpdate()
    {
        //body.velocity = new Vector2(hValue * Time.fixedDeltaTime * speed, body.velocity.y);
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
 
        if (health <= 0)
        {
            Die();
        }
    }
 
    void Die ()
    {
        Destroy(gameObject);
    }
}
