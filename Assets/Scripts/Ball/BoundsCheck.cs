using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to check if the ball has left the play area, and trigger the game over screen

public class BoundsCheck : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private void OnTriggerExit(Collider other)  //Checks to see if the ball has left the play area
    {
        if(other.gameObject.tag == "Player")
        {
            timer.gameActive = false; //Triggers the game over screen
        }
    }
}
