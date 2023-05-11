using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private RunJumpManager _runJumpManager;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _runJumpManager = FindObjectOfType<RunJumpManager>();
    }
    // Update is called once per frame
    void Update()
    {
        _text.text = $"Remaining: {_runJumpManager.TimeRemaining.ToString("0.0")}";
    }
}
