using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Button nextLevelButton;
    public Button mainMenuButton;
    public int counter = 0; //level counter

    void Start()
    {
        nextLevelButton.onClick.AddListener(nextLevel);
        mainMenuButton.onClick.AddListener(mainMenu);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void nextLevel()
    {
        counter++; //Increase level

        if (counter > 2)
        {
            SceneManager.LoadScene("Finish");
        }
        else
        {
            string nextLevelName = "Level" + (counter + 1);
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
