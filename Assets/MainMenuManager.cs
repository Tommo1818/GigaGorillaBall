using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/tutoriallevel");
    }

    public void OpenSettings()
    {
        // Load a Settings scene or display a settings panel
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}