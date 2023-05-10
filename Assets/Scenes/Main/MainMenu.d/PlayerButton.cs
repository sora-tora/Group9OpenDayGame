using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.MainMenu
{
    public class PlayerButton : MonoBehaviour
    {
        public void ButtonPush(int pCount)
        {
            PlayerTracker.PlayerCount = pCount;
            SceneManager.LoadScene(1);
        }
    }
}