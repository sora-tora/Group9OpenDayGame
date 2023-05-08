using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // UI Text-TextMeshPro

    [Header ("Component")]
    public TextMeshProUGUI timerText;

    [Header ("Timer Settings")]
    public float startTime;
    [HideInInspector]
    public float currentTime;
    public bool countUp;

    [Header ("Limit Settings")]
    public bool noLimit;
    // 0.49
    public float timerLimit;

    private float tempHold;

    // Start is called before the first frame update
    void Start()
    {
        // if (countUp)
        // {
        //     tempHold = startTime;
        //     startTime = timerLimit;
        //     timerLimit = tempHold;
        // }

        currentTime = startTime;
        if (!countUp)
        {
            timerLimit += 0.49f;            
        }

        if (countUp)
        {
            timerLimit -= 0.50f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countUp ? currentTime += Time.deltaTime : currentTime -= Time.deltaTime;

        if(!noLimit&&(!countUp && currentTime <= timerLimit) || (countUp && currentTime >= timerLimit))
        {
            currentTime = timerLimit;
            timerText.color = Color.red;
            SetTimerText();
            enabled=false;
        }

        SetTimerText();
    }
    
    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }
}
