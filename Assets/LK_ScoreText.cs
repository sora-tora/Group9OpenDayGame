using TMPro;
using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LK_ScoreText : MonoBehaviour
    {
        public LK_MinigameManager _minigameManager;
        private TextMeshProUGUI _textMeshProUGUI;

        private void Awake()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            _textMeshProUGUI.text = $"SCORE {_minigameManager.Score}\nREMAINING TIME: {_minigameManager.RemainingTime.ToString("0.0")} s";
        }
    }
}