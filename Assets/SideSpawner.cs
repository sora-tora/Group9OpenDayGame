using Game.Overworld;
using Game;
using Minigames.Logan.Minigame1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.Logan.MinigameRun
{
    public class SideSpawner : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        private PlayerSpawnPoint[] spawns;

        private void Awake()
        {
            if (PlayerTracker.PlayerCount == 0) { PlayerTracker.PlayerCount = 1; };
            spawns = FindObjectsOfType<PlayerSpawnPoint>();
        }

        private void Start()
        {
            for (int i = 0; i < PlayerTracker.PlayerCount; i++)
            {
                GameObject newPlayer = Instantiate(PlayerPrefab);
                newPlayer.transform.position = spawns[i].transform.position;
            }
        }
    }
}