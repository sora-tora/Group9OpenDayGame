using Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = $"Boss Health: {PlayerTracker.BossCurrentHealth}";
    }
}
