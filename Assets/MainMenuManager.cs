using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject buttoncluster;
    public GameObject settingscluster;
    public GameObject resetMessage;
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/tutoriallevel");
    }

    public void OpenSettings()
    {
        // Load a Settings scene or display a settings panel
    }

    public void LevelSelect()
    {
        buttoncluster.SetActive(!buttoncluster.activeSelf);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene("Scenes/" + levelName);
    }

    public void ShowSettings()
    {
        settingscluster.SetActive(!settingscluster.activeSelf);
    }

    public void ResetPlayerData()
    {
        PlayerPrefs.DeleteAll();
        ToggleResetMessage();
        Invoke("ToggleResetMessage", 2);
    }

    private void ToggleResetMessage()
    {
        resetMessage.SetActive(!resetMessage.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}