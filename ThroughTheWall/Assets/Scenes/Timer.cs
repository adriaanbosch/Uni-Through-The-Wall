using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text scoreText;
    private float secondsCount;
   
    void Update()
    {
        UpdateTimerUI();
    }

    public float getSecondsCount() {
        return this.secondsCount;
    }

    public void UpdateTimerUI()
    {
        scoreText.transform.position = new Vector2(Screen.width-120, Screen.height-50);
        secondsCount += Time.deltaTime;

        scoreText.text = "Score: " + ((int)secondsCount).ToString("0000");
        
    }
}
