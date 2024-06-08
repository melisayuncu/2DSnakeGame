using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   
    //direction of player's movements
    private Vector2 direction = Vector2.right;
    //list to store the body parts of the snake
    private List<Transform> body;
    public Transform bodyPrefab;
    //control the movement state
    private bool isMoving = true; 

    //represents playable area
    public BoxCollider2D Area;
    public bool isGameOver = false;
    public LevelManager levelManager;


    // Start is called before the first frame update
    void Start()
    {
        body = new List<Transform>();
        body.Add(this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Vector2.down;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Vector2.right;
            }

        }
        //stop movement state when P is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            isMoving = !isMoving;
        }

    }
        

    private void FixedUpdate()
    {
        if (isMoving) //move the player's body parts
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].position = body[i - 1].position;
            }
            this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y) + direction.y, 0.0f);

        }
    }
   
    //add a body part to snake
    private void Body()
    {
        Transform fullBody = Instantiate(this.bodyPrefab);
        fullBody.position = body[body.Count - 1].position;
        body.Add(fullBody);
    }

    //reset the player's position
    private void Reset()
    {
        for(int i = 1; i<body.Count; i++)
        {
            Destroy(body[i].gameObject); //destroy body parts
        }
        body.Clear();
        body.Add(this.transform);

        //reset the player's position to the center of the area
        Bounds bounds = this.Area.bounds;

        this.transform.position = bounds.center;
        //reset the direction
        direction = Vector2.right;
        isMoving = true; //ensure the snake starts moving after reset

        isGameOver = false;

    }

    //restart the game
    private void RestartGame()
    {

        Reset(); // reset player
        Score.instance.ResetScore(); // reset score
 

    }

    //if the player collides with apple or wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Apple")
        {
            Body(); //add body part when it collides with apple
            Score.instance.AddPoint(); //increase score
            levelManager.CollectApple(); 
            
        }
        else if(collision.tag == "Wall")
        {
            GameOver(); //if collides with wall, game over
            
        }
    }

    private void GameOver()
    {

        isMoving = false; //stop movement
        isGameOver = true;
        SceneManager.LoadScene("GameOver"); //load game over scene
        levelManager.RestartLevel(); //restart the level
        
    }
}
