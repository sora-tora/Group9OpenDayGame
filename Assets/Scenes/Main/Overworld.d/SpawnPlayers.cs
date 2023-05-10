using Minigames.Logan.Minigame1;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Overworld
{
    public class SpawnPlayers : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        private PlayerSpawnPoint[] spawns;
        
        private void Awake()
        {
            if (PlayerTracker.PlayerCount == 0 ) { PlayerTracker.PlayerCount = 1; };
            spawns = FindObjectsOfType<PlayerSpawnPoint>();
        }
        
        private void Start()
        {
            for (int i = 0; i < PlayerTracker.PlayerCount; i++)
            {
                GameObject newPlayer = Instantiate(PlayerPrefab);
                newPlayer.transform.position = spawns[i].transform.position;
                LK_TopDownPlayerController playerController = newPlayer.GetComponent<LK_TopDownPlayerController>();
                if (playerController != null )
                {
                    playerController.MoveUpKey = (i == 0 ? PlayerTracker.P1_UP : PlayerTracker.P2_UP);
                    playerController.MoveDownKey = (i == 0? PlayerTracker.P1_DOWN : PlayerTracker.P2_DOWN);
                    playerController.MoveRightKey = (i == 0? PlayerTracker.P1_RIGHT : PlayerTracker.P2_RIGHT);
                    playerController.MoveLeftKey = (i == 0 ? PlayerTracker.P1_LEFT : PlayerTracker.P2_LEFT);
                }
                playerController.AddComponent<PlayerLimits>();
            }
        }
    }
}