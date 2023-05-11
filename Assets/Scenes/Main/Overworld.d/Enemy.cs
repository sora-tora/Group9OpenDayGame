using Minigames.Logan.Minigame1;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Overworld
{
    public class Enemy : MonoBehaviour
    {
        LK_ColTrigger col;
        float lastDefeat = 0f;
        private void Awake()
        {
            col = GetComponent<LK_ColTrigger>();
        }
        private void Update()
        {
            if (lastDefeat <= 0f)
            {
                foreach (Collider2D colin in col.Colliders)
                {
                    if (colin.gameObject.GetComponent<LK_TopDownPlayerController>() != null)
                    {
                        // load scene additively
                        SceneManager.LoadScene(2);
                        // disable movement
                        foreach (LK_TopDownPlayerController player in FindObjectsOfType<LK_TopDownPlayerController>())
                        {
                            player.enabled = false;
                        }
                    }
                }
            }
            else
            {
                lastDefeat -= Time.deltaTime;
            }
        }
    }
}