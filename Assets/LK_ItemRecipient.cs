using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames.Logan.Minigame1
{
    public class LK_ItemRecipient : MonoBehaviour
    {
        public bool Satisfied = false;
        public List<string> QualifiedItemNames = new List<string>();
        public string PreferredItemName;

        private LK_MinigameManager _minigameManager;

        public UnityEvent ItemReceivedEvent;

        private void Awake()
        {
            _minigameManager = FindObjectOfType<LK_MinigameManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public int GiveItem(GameObject item)
        {
            int score = 0;

            Debug.Log($"{gameObject.name} is recieving {item.name}");
            LK_Item itemInfo = item.GetComponent<LK_Item>();

            string itemName = itemInfo.item.Name;

            if (itemName == PreferredItemName)
            {
                // award extra points
                score += 5;
            }
            else if (QualifiedItemNames.Contains(itemName))
            {
                // award normal points
                score += 2;
            }
            else
            {
                // this doesn't want this item, take away points from player
                score -= 2;
            }

            _minigameManager.GameObjectsInPlay.Remove(item);

            Destroy(item);
            ItemReceivedEvent.Invoke();

            return score;
        }
    }
}