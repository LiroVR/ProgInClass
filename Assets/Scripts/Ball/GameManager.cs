using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

//Manages most game-related functions, such as game over, saving and loading high scores, and loading the leaderboard


public class GameManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Timer timer;
    [SerializeField] private GameObject gameOverPanel, game, scorePrefab, leaderboard, playerObject;
    [SerializeField] private TMP_InputField playerName;
    private bool gameOver = false;
    private List<string> highScoreNames = new List<string>();
    private List<int> highScores = new List<int>();

    void Update()
    {
        if (timer.gameActive == false) //Checks to see if time has run out
        {
            if (!gameOver)
            {
                game.SetActive(false);
                gameOverPanel.SetActive(true);
            }
            gameOver = true;
        }
    }

    public void SavePlayerData() //Saves the player's name and score to a text file
    {
        string filePath = Application.persistentDataPath + "/highScores.txt";
        StreamWriter writer = new StreamWriter(filePath, true);
        if (playerName.text == "") //If the player didn't enter a name, it defaults to "Anonymous"
        {
            playerName.text = "Anonymous";
        }
        else if (playerName.text.Contains(" ")) //If the player enters a space in their name, it replaces it with an underscore
        {
            playerName.text = playerName.text.Replace(" ", "_"); //Replaces spaces with underscores, so the text file can be read properly
        }
        if(playerName.text.Length > 15) //If the player's name is longer than 15 characters, it truncates it to 15 characters
        {
            playerName.text = playerName.text.Substring(0, 15);
        }
        writer.WriteLine(playerName.text + " " + scoreManager.score.ToString());
        writer.Close();
        //Debug.Log("Saved");
    }

    public void LoadPlayerData() //Loads the high scores from the text file
    {
        string filePath = Application.persistentDataPath + "/highScores.txt";
        StreamReader reader = new StreamReader(filePath);
        string line = reader.ReadLine();
        highScoreNames.Clear();
        highScores.Clear();
        //Debug.Log(line);
        while (line != null)
        {
            string[] tempLine = line.Split('\n'); //Splits the whole text file into individual lines
            for (int i = 0; i < tempLine.Length; i++)
            {
                string[] tempScore = tempLine[i].Split(' '); //Splits each line into a name and a score
                highScoreNames.Add(tempScore[0]);
                //Debug.Log(tempScore[0]);
                highScores.Add(int.Parse(tempScore[1]));
            }
            line = reader.ReadLine();
        }
        reader.Close();
    }

    public void SortHighScores() //Sorts the high scores from highest to lowest
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            for (int j = i + 1; j < highScores.Count; j++)
            {
                if (highScores[j] > highScores[i])
                {
                    int tempScore = highScores[i];
                    highScores[i] = highScores[j];
                    highScores[j] = tempScore;

                    string tempName = highScoreNames[i];
                    highScoreNames[i] = highScoreNames[j];
                    highScoreNames[j] = tempName;
                }
            }
        }
    }

    public void LoadLeaderboard() //Loads the leaderboard to display the high scores
    {
        LoadPlayerData();
        SortHighScores();
        for (int i = 0; i < 6; i++)
        {
            try
            {
                GameObject.Destroy(leaderboard.transform.GetChild(2+i).gameObject); //Destroys the previous leaderboard text, so it doesn't overlay if they choose the leaderboard again
            }
            catch
            {
                break;
            }
        }
        if(highScores.Count >= 6) //If there are more than 6 high scores, it only displays the top 6
        {
            for (int i = 0; i < 6; i++)
            {
                var scoreDisplay = Instantiate(scorePrefab, leaderboard.transform);
                scoreDisplay.GetComponent<RectTransform>().localPosition = new Vector3(0, (125-(50*i)), 0); //Positions the text on the leaderboard, with an offset of 50
                scoreDisplay.GetComponent<TextMeshProUGUI>().text = (highScoreNames[i] + " --- " + highScores[i]);
            }
        }
        else
        {
            for (int i = 0; i < highScores.Count; i++)
            {
                var scoreDisplay = Instantiate(scorePrefab, leaderboard.transform);
                scoreDisplay.GetComponent<RectTransform>().localPosition = new Vector3(0, (125-(50*i)), 0);
                scoreDisplay.GetComponent<TextMeshProUGUI>().text = (highScoreNames[i] + " --- " + highScores[i]);
            }
        }
    }

    public void loadScene(string sceneName) //Loads the scene with the name passed in
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() //Quits the game
    {
        Application.Quit();
    }

    public void ResetGame() //Resets the game
    {
        timer.gameActive = true;
        gameOver = false;
        timer.timeLeft = 59;
        scoreManager.score = 0;
        playerObject.transform.position = new Vector3(0f, 0.5f, 0f);
        playerObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        playerObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        playerName.text = "";
    }
}
