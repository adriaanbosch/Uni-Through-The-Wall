using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    void Update()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;

        timerText.text = "Time Survived: " + hourCount + "h: " + minuteCount.ToString("00") + "m: " + ((int)secondsCount).ToString("00") + "s";

        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount %= 60;
            
            if (minuteCount >= 60)
            {
                hourCount++;
                minuteCount %= 60;
            }
        }
    }
}
