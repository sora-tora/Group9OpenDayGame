using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target; //where we want to shoot(player? mouse?)
    public Transform weaponMuzzle; //The empty game object which will be our weapon muzzle to shoot from
    public GameObject bullet; //Your set-up prefab
    public float fireRate = 3000f; //Fire every 3 seconds
    public float shootingPower = 1f; //force of projection
 
 
    private float shootingTime; //local to store last time we shot so we can make sure its done every 3s
 
    public int health = 100;
 
    private void Update()
    {
        Fire(); //Constantly fire
    }
 
    private void Fire()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity); //create our bullet
            Vector2 direction = (Vector2)target.position - myPos; //get the direction to the target
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower; //shoot the bullet
        }
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
