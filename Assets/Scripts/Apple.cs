using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private AutoScale wallScaler; 
    public BoxCollider2D Area; //area where the Apple can spawn


    // Start is called before the first frame update
    void Start()
    {
        wallScaler = FindObjectOfType<AutoScale>(); //find and assign the AutoScale script
        RandomizePosition(); //randomize the initial position of the apple
    } 
    void Update()
    {
        //check if the apple is colliding with any wall
        if (IsCollidingWithWall())
        {
            RandomizePosition(); //if collides randomize the position again
        }
    }
    public void RandomizePosition()
    {
        Bounds bounds = this.Area.bounds; //boundaries of the spawn area
                  
        //randomly generate the coordinates 
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    //if apple collides with wall
    private bool IsCollidingWithWall()
    {
  
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.5f);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Wall"))
            {
                return true; //if collides return true
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the apple collides with the player or a wall, randomize its position again
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            RandomizePosition();
        }
    }

}
