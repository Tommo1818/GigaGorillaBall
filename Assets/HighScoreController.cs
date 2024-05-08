using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    private string sceneName; // The name of the current scene
    private int bananaCount; // The current banana count
    private int time; // The current time
    public TMPro.TextMeshProUGUI highscoretext; // Reference to a TextMeshProUGUI object

    void Start()
    {
    }

    public void UpdateHighScores()
    {
        Debug.Log("UpdateHighScores called");
        // Get the name of the current scene
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        // get the banana count and time from the PlayerPrefs
        bananaCount = PlayerPrefs.GetInt(sceneName + "_bananas", 0);
        time = PlayerPrefs.GetInt(sceneName + "_time", 0);

        // Load the best banana count and fastest time
        int bestBananaCount = PlayerPrefs.GetInt(sceneName + "_bestBananas", 0);
        int fastestTime = PlayerPrefs.GetInt(sceneName + "_fastestTime", int.MaxValue);

        // If the current banana count is greater than the best banana count
        if (bananaCount > bestBananaCount)
        {
            // Update the best banana count
            PlayerPrefs.SetInt(sceneName + "_bestBananas", bananaCount);
        }

        // If the current time is less than the fastest time
        if (time < fastestTime)
        {
            // Update the fastest time
            PlayerPrefs.SetInt(sceneName + "_fastestTime", time);
        }

        // Update the highscore text
        int fastestTimeInSeconds = PlayerPrefs.GetInt(sceneName + "_fastestTime", 0);
        int minutes = fastestTimeInSeconds / 60;
        int seconds = fastestTimeInSeconds % 60;
        highscoretext.text = "Fastest Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + "\nBest Bananas: " + PlayerPrefs.GetInt(sceneName + "_bestBananas", 0);
    }
}