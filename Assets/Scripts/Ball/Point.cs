using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to keep track of the player's score, and display it on the screen
public class Point : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject audioSpawn;
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player") //If the ball collides with the player, the player's score increases by 1
        {
            scoreManager.score++;
            Instantiate(audioSpawn, transform.position, Quaternion.identity); //Spawns the collection audio at the point's position
            Object.Destroy(this.gameObject); //Destroys the point object
            scoreManager.scoreText.text = ("Score: " + scoreManager.score.ToString()); //Updates the score text
        }
    }
}
