using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public void Start()
    {   
        playButton.onClick.AddListener(PlayButton);     
        quitButton.onClick.AddListener(QuitButton);
        
    }

    public void PlayButton()
    {       
        SceneManager.LoadScene("Level1");

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}