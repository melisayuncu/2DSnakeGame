using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Button mainMenuButton;
    public Button quitButton;

    public void Start()
    {
        
        mainMenuButton.onClick.AddListener(OnMainMenu);          
        quitButton.onClick.AddListener(QuitButton);
    }

    public void OnMainMenu()
    {
        Score.instance.ResetScore();
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
