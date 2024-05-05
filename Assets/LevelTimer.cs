using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class LevelTimer : MonoBehaviour
{
    private bool levelFinished = false;
    private float startTime;
    public TextMeshProUGUI timerText; // Use TextMeshProUGUI for UI text, TextMeshPro for 3D text

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (levelFinished) 
            return;

        float timeElapsed = Time.time - startTime;

        int minutes = (int)(timeElapsed / 60); 
        int seconds = (int)(timeElapsed % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void FinishLevel()
    {
        levelFinished = true;
    }
}