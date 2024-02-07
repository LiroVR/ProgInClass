using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private WaitForSeconds gameTimer;
    [SerializeField] private int timeLeft = 60;
    [SerializeField] private TextMeshProUGUI timerText;
    public bool gameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = new WaitForSeconds(1);
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (timeLeft >= 0)
        {
            yield return gameTimer;
            timerText.text = ("Time: " + timeLeft.ToString());
            timeLeft--;
            //Debug.Log("Time Left: " + timeLeft);
        }

        gameActive = false;
        //Debug.Log("Game Over");
    }
}
