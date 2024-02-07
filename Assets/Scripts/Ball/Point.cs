using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scoreManager.score++;
            Object.Destroy(this.gameObject);
            scoreManager.scoreText.text = ("Score: " + scoreManager.score.ToString());
        }
    }
}
