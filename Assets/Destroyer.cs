using Game;
using MiniGames.Logan.MinigameRun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float playersKilled = 0f;
    private RunJumpManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<RunJumpManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LK_JumpController jumper = collision.GetComponent<LK_JumpController>();
        if (jumper != null)
        {
            playersKilled++;
            if (playersKilled >= PlayerTracker.PlayerCount)
            {
                // game over
                _manager.FinishGame();
            }
        }
        Destroy(collision.gameObject);
    }
}
