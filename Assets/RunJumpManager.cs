using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class RunJumpManager : MonoBehaviour
{
    public const float MAX_TIME = 20f;
    public float TimeRemaining = MAX_TIME;

    private void Update()
    {
        TimeRemaining -= Time.deltaTime;
        if (TimeRemaining < 0 )
        {
            FinishGame();
        }
    }

    public void FinishGame()
    {
        PlayerTracker.BossCurrentHealth -= 0.5f * (MAX_TIME - TimeRemaining);
        SceneManager.LoadScene(1);
    }
}
