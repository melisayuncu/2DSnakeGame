using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Button restartButton;
    public Button menuButton;
    public void Start()
    {
        restartButton.onClick.AddListener(RestartGame); //when clicked on Restart button
        menuButton.onClick.AddListener(GoToMainMenu); //when clicked on Main Menu button

    }

    public void RestartGame()
    {
        Score.instance.ResetScore();
        //Restart the game
        SceneManager.LoadScene("Level1"); 
    }

    public void GoToMainMenu()
    {
        Score.instance.ResetScore();
        //Go back to main menu
        SceneManager.LoadScene("MainMenu"); 
    }
}
