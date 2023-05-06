using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnDisable()
    {
        //Colliders.Clear();
    }

    public GameObject GetClosest()
    {
        GameObject closest = null;
        float closestDistance = 1000f;
        foreach(Collider2D col in Colliders) 
        { 
            float dist = Vector3.Distance(transform.position, col.transform.position);
            if (dist < closestDistance)
                closest = col.gameObject;
        }
        return closest;
    }
}
