using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScores : MonoBehaviour
{
    public Text highScores;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreUI();
    }

    public void UpdateScoreUI() 
    {
        //highScores.transform.position = new Vector2(300, 120);
        string currentScores = "";
        currentScores += "1st     " + PlayerPrefs.GetInt("HighScore0") + "\n";
        currentScores += "2nd    " + PlayerPrefs.GetInt("HighScore1") + "\n";
        currentScores += "3rd     " + PlayerPrefs.GetInt("HighScore2") + "\n";
        currentScores += "4th     " + PlayerPrefs.GetInt("HighScore3") + "\n";
        currentScores += "5th     " + PlayerPrefs.GetInt("HighScore4") + "\n";

        highScores.text = currentScores;
        // PlayerPrefs.GetInt("HighScore0");
        // PlayerPrefs.GetInt("HighScore1");
    }
}
