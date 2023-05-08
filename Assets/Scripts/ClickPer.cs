using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickPer : MonoBehaviour
{
    [Header ("Component")]
    public TextMeshProUGUI beatPText;

    float lastTime;
    float bp;
    public float per;

    [Header ("Range")]
    // 0.49
    public float lowerRange;
    public float upperRange;
 
    void Update() 
    {
        beatPText.color = Color.white;

        if (Input.GetMouseButtonDown(0)) 
        {
 
            float currentTime = Time.time;
            float diff = currentTime - lastTime;
            lastTime = currentTime;
            bp = per / diff;
            PrintBP();
        }

        if (bp >= lowerRange && bp <= upperRange)
        {
            beatPText.color = Color.green;
        }

    }

    private void PrintBP()
    {
        beatPText.text = bp.ToString("0");
    }
}
