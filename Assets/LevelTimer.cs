using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro
using UnityEngine.SceneManagement;
public class LevelTimer : MonoBehaviour
{
    private bool levelFinished = false;
    private float startTime;
    public TextMeshProUGUI timerText; // Use TextMeshProUGUI for UI text, TextMeshPro for 3D text
    private string sceneName;
    public GameObject player;
    public GameObject finalScoreText;
    private float finishTime;

    void Start()
    {
        startTime = Time.time;
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (levelFinished) 
            return;

        finishTime = Time.time - startTime;

        int minutes = (int)(finishTime / 60); 
        int seconds = (int)(finishTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void FinishLevel()
    {
        levelFinished = true;

        ItemCollector itemCollector = player.GetComponent<ItemCollector>();

        PlayerPrefs.SetInt(sceneName + "_time", (int)finishTime);
        PlayerPrefs.SetInt(sceneName + "_bananas", itemCollector.bananaCount);
        int minutes = (int)(finishTime / 60); 
        int seconds = (int)(finishTime % 60);

        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        finalScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: " + timeText + "\nBananas: " + PlayerPrefs.GetInt(sceneName + "_bananas");
        finalScoreText.SetActive(true);
    }
}