using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerFinish : MonoBehaviour
{
    public LevelTimer levelTimer; // Reference to the LevelTimer script
    public GameObject triggerObject; // The object that triggers the finish
    public GameObject finishText; // The text to display when the level is finished
    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    public HighScoreController highScoreController; // Reference to the HighScoreController script
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the trigger object
        if (other.gameObject == triggerObject)
        {
            // Check if levelTimer is not null
            if (levelTimer != null)
            {
                // Call the FinishLevel method
                levelTimer.FinishLevel();
                finishText.SetActive(true);
                highScoreController.UpdateHighScores();
            }
            else
            {
                Debug.LogError("LevelTimer is not assigned in the Inspector");
            }
        }
    }
}
