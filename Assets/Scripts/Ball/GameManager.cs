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
    private List<string> highScoreNames = new List<string>();
    private List<int> highScores = new List<int>();

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
        StreamWriter writer = new StreamWriter(filePath, true);
        writer.WriteLine(playerName.text + " " + scoreManager.score.ToString());
        writer.Close();
        //Debug.Log("Saved");
    }

    public void LoadPlayerData()
    {
        string filePath = Application.persistentDataPath + "/highScores.txt";
        StreamReader reader = new StreamReader(filePath);
        string line = reader.ReadLine();
        while (line != null)
        {
            //Debug.Log(line);
            line = reader.ReadLine();
            string tempRead = reader.ReadLine();
            string[] tempLine = tempRead.Split('\n');
            for (int i = 0; i < tempLine.Length; i++)
            {
                string[] tempScore = tempLine[i].Split(' ');
                highScoreNames.Add(tempScore[0]);
                highScores.Add(int.Parse(tempScore[1]));
            }
        }
        reader.Close();
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
