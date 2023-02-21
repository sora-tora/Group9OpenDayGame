using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace OpenDayGame.MainMenu
{
    /// <summary>
    /// Temporary scene switcher. Gathers all scenes in build settings and creates button to load each one.
    /// </summary>
    public class SceneSelectMenu : MonoBehaviour
    {
        private Scene[] _scenes;
        
        public Transform ViewportContent;
        public GameObject ButtonPrefab;

        // Start is called before the first frame update
        void Start()
        {
            _scenes = new Scene[SceneManager.sceneCountInBuildSettings];
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                _scenes[i] = SceneManager.GetSceneByBuildIndex(i);

                GameObject newButton = Instantiate(ButtonPrefab, ViewportContent);
                RectTransform rect = newButton.GetComponent<RectTransform>();
                rect.localPosition = new Vector2(0, -30 * i);
                SceneSelectButton button = newButton.GetComponent<SceneSelectButton>();
                button.SceneIndex = i;
                TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
                text.text = _scenes[i].name;
                // if scene name isn't available, show the path (I think unloaded scenes do not have names for whatever reason)
                if (string.IsNullOrEmpty(text.text))
                    text.text = SceneUtility.GetScenePathByBuildIndex(i);
            }
            ;
        }
    }
}