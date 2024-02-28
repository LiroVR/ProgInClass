using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Used to keep track of the time left in the game, and display it on the screen
public class Timer : MonoBehaviour
{
    private WaitForSeconds gameTimer;
    public int timeLeft = 60;
    [SerializeField] private TextMeshProUGUI timerText;
    public bool gameActive = true;

    // Start is called before the first frame update
    void OnEnable()
    {
        gameTimer = new WaitForSeconds(1); //Creates a new WaitForSeconds object, with a duration of 1 second
        timerText.text = ("Time: " + timeLeft.ToString());
        StartCoroutine(CountdownTimer()); //Starts the countdown timer
    }

    IEnumerator CountdownTimer()
    {
        while (timeLeft >= 0) //Keeps counting down until time runs out
        {
            yield return gameTimer;
            timerText.text = ("Time: " + timeLeft.ToString());
            timeLeft--;
            //Debug.Log("Time Left: " + timeLeft);
        }

        gameActive = false; //Triggers the game over screen
        //Debug.Log("Game Over");
    }
}
