using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static Score instance;
    public Text scoreText;
    public Text highscoreText;
    int score = 0; //current score
    int highscore = 0; 
    
    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       //loads current score and highscore from PlayerPrefs
        score = PlayerPrefs.GetInt("currentScore", 0);
        highscore = PlayerPrefs.GetInt("highscore", 0);
       
        //update UI to display current and high score
        UpdateScoreText();
        UpdateHighscoreText();

    }

    //Add a point to the score
    public void AddPoint()
    {
        score += 1; //increment score by 1
        UpdateScoreText(); //update UI

        //update highscore if the new score is higher than the current highscore
        if (highscore < score) 
        {
            highscore = score; //update
            PlayerPrefs.SetInt("highscore", highscore); //save highscore to Playerprefs
            UpdateHighscoreText(); //update UI
        }
        
    }

    //reset the score to zero
    public void ResetScore()
    {
        if(score != null)
        {
            score = 0; //reset score
            PlayerPrefs.SetInt("currentScore", score);
            UpdateScoreText(); //update UI to display reset score
        }
     
       
    }
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        // Skoru PlayerPrefs'te saklayýn
        PlayerPrefs.SetInt("currentScore", score);
    }

    void UpdateHighscoreText()
    {
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
}
