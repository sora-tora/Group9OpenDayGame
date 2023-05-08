using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    //private float speed = 6;
    public float timer;
    public int damage = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity=transform.right*speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1.0F * Time.deltaTime;
         if (timer >= 4)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Player_Controller player = HitInfo.GetComponent<Player_Controller>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
 
        Debug.Log(HitInfo.name);
        Destroy(gameObject);
    }
}
