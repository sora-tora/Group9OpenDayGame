using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Minigames.Logan.Minigame1
{
    public class LK_MinigameManager : MonoBehaviour
    {
        private int _score = 0;
        public int Score
        {
            get { return _score; }
            set
            {
                int diff = value - _score;
                _score = value;
                Debug.Log($"Changing player score by {diff} to {_score}");
            }
        }
        public float RemainingTime = 20f;
        public List<GameObject> GameObjectsInPlay = new List<GameObject>();
        public LK_ItemSpawner Spawner;

        public LK_ItemRecipient[] Recipients;

        private bool _isGameRunning = false;
        public bool IsGameRunning
        {
            get { return _isGameRunning; }
            set
            {
                _isGameRunning = value;
                IsGameRunning_ChangedEvent.Invoke();
            }
        }
        public UnityEvent IsGameRunning_ChangedEvent;

        private void Awake()
        {
            Recipients = FindObjectsOfType<LK_ItemRecipient>();
            IsGameRunning_ChangedEvent.AddListener(On_IsGameRunning_Changed);
        }

        public int GetScore()
        {
            return Score;
        }

        private float _tsecond = 0f;

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

            IsGameRunning = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsGameRunning)
            {
                // may as well try respawn the objects:
                _tsecond += Time.deltaTime;
                if (_tsecond > 1f)
                {
                    _tsecond = 0f;
                    SpawnObjects();
                }
                RemainingTime -= Time.deltaTime;
                if (RemainingTime <= 0f)
                {
                    IsGameRunning = false;
                    Debug.Log("Finish game :)");
                }
            }
        }

        private void SpawnObjects()
        {
            if (GameObjectsInPlay.Count > 0)
            {
                //Debug.LogWarning("There are still gameobjects in play, not spawning any more");
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

        private void On_IsGameRunning_Changed()
        {
            if (IsGameRunning)
            {
                // Game has just started
            }
            else
            {
                // Game has just finished
                PlayerTracker.BossCurrentHealth -= 1.5f * Score;
                SceneManager.LoadScene(1);
            }
        }
    }
}