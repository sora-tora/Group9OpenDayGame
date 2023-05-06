using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    public class LK_ItemSpawner : MonoBehaviour
    {
        public LK_MinigameItem[] Items;
        public int ItemCount = 4;
        public float ItemSpacing = 1f;

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

        public GameObject[] SpawnItems()
        {
            Debug.Log("Spawning Items");
            GameObject[] spawnedObjs = new GameObject[ItemCount];
            for (int i = 0; i < ItemCount; i++)
            {
                Vector3 pos = transform.position + Vector3.right * ItemSpacing * i;
                pos.z = -0.1f;
                int itemIndex = Random.Range(0, Items.Length);
                GameObject spawned = Instantiate(Items[itemIndex].SpawnableObject);
                spawnedObjs[i] = spawned;
                spawned.AddComponent<LK_Item>().item = Items[itemIndex];
                spawned.transform.position = pos;
            }
            return spawnedObjs;
        }
    }
}