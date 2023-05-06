using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    public class LK_MinigameManager : MonoBehaviour
    {
        public int Score = 0;
        public float RemainingTime = 50f;
        public List<GameObject> GameObjectsInPlay = new List<GameObject>();
        public LK_ItemSpawner Spawner;

        public LK_ItemRecipient[] Recipients;

        // Start is called before the first frame update
        void Start()
        {
            // set recipient qualified item names
            foreach(LK_MinigameItem item in Spawner.Items)
            {
                foreach(LK_ItemRecipient recipient in item.QualifiedRecipients)
                {
                    recipient.QualifiedItemNames.Add(item.Name);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SpawnObjects();
            }
        }

        private void SpawnObjects()
        {
            if (GameObjectsInPlay.Count > 0)
            {
                Debug.LogWarning("There are still gameobjects in play, not spawning any more");
            }
            else
            {
                GameObjectsInPlay.AddRange(Spawner.SpawnItems());
                Debug.Log("Spawning objects");
                // setup list of qualified items in recipients
                foreach(GameObject item in GameObjectsInPlay)
                {
                    
                }
            }

            // change preferred items of recipients
            foreach(LK_ItemRecipient recipient in  Recipients)
            {
                recipient.PreferredItemName = recipient.QualifiedItemNames[Random.Range(0, recipient.QualifiedItemNames.Count)];
            }
        }
    }
}