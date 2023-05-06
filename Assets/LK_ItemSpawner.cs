using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LK_ItemSpawner : MonoBehaviour
{
    public LK_MinigameItem[] Items;
    public int ItemCount = 4;
    public float ItemSpacing = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < ItemCount; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position + Vector3.right * ItemSpacing * i, 0.1f);
        }
    }

    public void SpawnItems()
    {

    }
}
