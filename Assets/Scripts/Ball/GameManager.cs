using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Timer timer;
    [SerializeField] private GameObject gameOverPanel, game;
    [SerializeField] private TMP_InputField playerName;
    private bool gameOver = false;

    void Update()
    {
        if (timer.gameActive == false)
        {
            if (!gameOver)
            {
                game.SetActive(false);
                gameOverPanel.SetActive(true);
            }
            gameOver = true;
        }
    }

    public void SavePlayerData()
    {
        string filePath = Application.persistentDataPath + "/highScores.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(playerName.text, scoreManager.score);
        }
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
