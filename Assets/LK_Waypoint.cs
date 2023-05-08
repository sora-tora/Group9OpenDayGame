using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Minigames.Logan.Minigame1
{
    public class LK_Waypoint : MonoBehaviour
    {
        private Image _img;
        private LK_ItemRecipient[] _recipients;
        public LK_PlayerHand Hand;
        private void Awake()
        {
            _img = GetComponent<Image>();
            _recipients = FindObjectsOfType<LK_ItemRecipient>();
        }

        private void Update()
        {
            // find the best destination
            LK_ItemRecipient best = null;
            int bestScore = 0;
            GameObject currentObj = Hand.CurrentItem;
            if (currentObj != null)
            {
                foreach (LK_ItemRecipient recipient in _recipients)
                {
                    int score = recipient.PretendGiveItem(currentObj);
                    if (score > bestScore)
                    {
                        best = recipient;
                        bestScore = score;
                    }
                }
                if (best != null)
                {
                    transform.position = Camera.main.WorldToScreenPoint(best.transform.position);
                    _img.enabled = true;
                }
            }
            else
            {
                _img.enabled = false;
            }
        }
    }
}