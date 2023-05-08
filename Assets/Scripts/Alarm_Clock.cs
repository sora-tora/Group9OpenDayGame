using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Alarm_Clock : MonoBehaviour
{
    // UI Text-TextMeshPro

    [Header ("Component")]
    public TextMeshProUGUI alarmText;

    [Header ("Timer")]
    private float takenStartTime;
    private float takenTime;

    [Header ("Limit")]
    // 0.49
    private float takenLimit;

    [Header ("Range")]
    // 0.49
    public float lowerRange;
    public float upperRange;
    
    private bool timerDone;

    private bool takenCountup;

    private int score = 0;

    private float tempHold;

    // Start is called before the first frame update
    void Start()
    {
        timerDone = false;
        takenLimit = FindObjectOfType<Timer>().timerLimit;
        takenStartTime = FindObjectOfType<Timer>().startTime;
        takenCountup = FindObjectOfType<Timer>().countUp;

        if (!takenCountup)
        {
            takenLimit += 0.49f;            
            lowerRange -= 0.50f;
            upperRange += 0.49f;
        }
        if (takenCountup)
        {
            takenLimit -= 0.50f;
            lowerRange -= 0.50f;
            upperRange += 0.49f;

            // tempHold = takenStartTime;
            // takenStartTime = takenLimit;
            // takenLimit = tempHold;
        }

        //lowerRange += 0.49f;
        //upperRange -= 0.50f;
    }

    // Update is called once per frame
    void Update()
    {
        takenTime = FindObjectOfType<Timer>().currentTime;
        
        if (!timerDone)
        {
            alarmText.text = takenTime.ToString("0");
        }

        if ((takenCountup && (takenTime <= takenLimit && (takenTime >= lowerRange && takenTime <= upperRange))))
        {
            alarmText.color = Color.green;
            countClick();             
        }

        if (takenCountup &&(!timerDone && (takenTime >= upperRange)))
        {
            alarmText.color = Color.white;
            printScore();  
        }

        if ((!takenCountup && (takenTime >= takenLimit && (takenTime >= lowerRange && takenTime <= upperRange))))
        {
            alarmText.color = Color.red;
            countClick();             
        }

        if (!takenCountup &&(!timerDone && (takenTime <= lowerRange)))
        {
            alarmText.color = Color.white;
            printScore();  
        }

        // if (takenTime > takenLimit && takenTime < lowerRange)
        // {
        //     Debug.Log("OUT OF RANGE");
        // }

        // if (takenTime > upperRange && takenTime < takenStartTime)
        // {
        //     Debug.Log("OUT OF RANGE");
        // }
    }

    void countClick()
    {
      if (Input.GetButtonDown("Jump"))
        {
          score ++; //it increments the score by 1
          //score += 1;        
        }
    }

    void printScore()
    {
        timerDone = true;        
        alarmText.color = Color.green;
        alarmText.text = score.ToString();
    }        
}
