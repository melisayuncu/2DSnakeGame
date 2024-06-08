using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Text levelInfoText;
    //list of required apples for each level (I just add 2 for 2 levels)
    private List<int> requiredAppleCounts = new List<int>() {8, 15}; 
    private int currentLevel = 1; 
    private int collectedAppleCount = 0;
    private bool isGameOver = false;
    public Button nextLevelButton;
    public Button mainMenuButton;


    void Start()
    {
        //update level info
        UpdateLevelInfo();
        nextLevelButton.onClick.AddListener(nextLevel);
        mainMenuButton.onClick.AddListener(mainMenu);
    }

    public void CollectApple()
    {
        collectedAppleCount++; //increment the collected apple count

        //check if the required number of apples for the next level is collected and the game is not over
        int requiredApplesForNextLevel = RequiredAppleCount();
        if (collectedAppleCount >= requiredApplesForNextLevel && !isGameOver)
        {
            ProceedToNextLevel();
            Score.instance.ResetScore();
        }
    }
    public void mainMenu()
    {
        //load main menu
        SceneManager.LoadScene("MainMenu");
    }
    public void nextLevel()
    {
        currentLevel = currentLevel + 1; //increment the current level
        UpdateLevelInfo(); 

        //if all levels are completed
        if (currentLevel >= requiredAppleCounts.Count)
        {
            SceneManager.LoadScene("Finish");
        }
        else
        {
            string nextLevelName = "Level" + (currentLevel); 
            SceneManager.LoadScene(nextLevelName);  //load next level
        }

    }
    //proceed to next level scene
    public void ProceedToNextLevel()
    {
        currentLevel = currentLevel + 1;
        collectedAppleCount = 0;

            SceneManager.LoadScene("NextLevel");

    }
    //reset the current level
    public void RestartLevel()
    {
        collectedAppleCount = 0;
        isGameOver = false;
    }

    //get the required apple count for the current level
    int RequiredAppleCount()
    {
        if (currentLevel < requiredAppleCounts.Count)
        {
            return requiredAppleCounts[currentLevel - 1];
        }
        else
        {
            return requiredAppleCounts[requiredAppleCounts.Count - 1];
        }
    }

    //update the level information UI
    void UpdateLevelInfo()
    {
        int requiredApplesForNextLevel = RequiredAppleCount();
        levelInfoText.text = "Level " + currentLevel + "\nCollect " + requiredApplesForNextLevel + " apples to proceed to the next level!";
        
    }


}
