using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public string nextLevelName; // The name of the next level

    // This method loads the next level
    public void GoToNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(nextLevelName);
    }

    // This method loads the main menu
    public void GoToMainMenu()
    {
        // Load the main menu scene
        // Replace "MainMenu" with the name of your main menu scene
        SceneManager.LoadScene("Scenes/mainmenu");
    }

    public void ResetLevel()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}