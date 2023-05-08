using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    [System.Serializable]
    public class LK_MinigameItem
    {
        public string Name;
        public GameObject SpawnableObject;
        public LK_ItemRecipient[] QualifiedRecipients;
    }
}