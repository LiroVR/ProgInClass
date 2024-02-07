using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject audioSpawn;
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scoreManager.score++;
            Instantiate(audioSpawn, transform.position, Quaternion.identity);
            Object.Destroy(this.gameObject);
            scoreManager.scoreText.text = ("Score: " + scoreManager.score.ToString());
        }
    }
}
