using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for SceneManager

public class FallDetector : MonoBehaviour
{
    // Reference to the player's game object (assign this in the Inspector)
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            PlayerDeath(); 
        }
    }

    private void PlayerDeath() // Made private as it's not being called from other scripts
    {
        // Option 2: Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
