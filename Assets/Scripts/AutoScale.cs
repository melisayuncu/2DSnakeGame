using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScale : MonoBehaviour
{
    
    //ratio for the scaling
    public Vector3 scaleRate = new Vector3(0.1f, 0.1f, 0.1f); 
    private bool isScaling = true;
    public Button restartButton;
    public Text countdownText;
    //countdown duration
    private int countdown = 5;
    //initial scale of the object
    private Vector3 initialScale;
    private Player player;


    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        initialScale = transform.localScale;

        //start the countdown
        StartCoroutine(StartCountdown());
        //find the player object
        player = FindObjectOfType<Player>(); 
    }
    
    void Update()
    {
        //start or stop scaling when clicked on "P"
        if (player.isGameOver == false && Input.GetKeyDown(KeyCode.P))
        {
            isScaling = !isScaling;
            
        }

        //when time is up, start scaling
        if (isScaling && countdown == -1)
        {
            transform.localScale += scaleRate * Time.deltaTime;
        }
    }

    private IEnumerator StartCountdown()
    {
        countdown = 5;
        while (countdown >= 0)
        {
            countdownText.text = "Last " + countdown.ToString() + " for RED ZONE!!";
            yield return new WaitForSeconds(1f);
            countdown--;
        }
            //when countdown stops, continue scaling
            isScaling = true;
        
    }
    private void RestartGame()
    {

        isScaling = true;


        //Reset the wall dimensions to the initial dimensions
        transform.localScale = initialScale;
        //initialize counter for restart
        StartCoroutine(StartCountdown());
    }
}

