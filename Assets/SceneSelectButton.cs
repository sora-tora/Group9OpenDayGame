using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace OpenDayGame.MainMenu
{
    /// <summary>
    /// Attach this component to a unity Button UI object.
    /// Automatically listens to the onClick event and loads the scene at specified index
    /// </summary>
    public class SceneSelectButton : MonoBehaviour
    {
        public int SceneIndex = 0;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SceneManager.LoadScene(SceneIndex, LoadSceneMode.Single);
        }
    }
}