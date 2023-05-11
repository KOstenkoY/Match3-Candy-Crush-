using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private const string _mainMenuSceneName = "Menu";
    private const string _gameplaySceneName = "LevelSelect";
    private const string _dataSceneName = "Data";

    public void OpenGameplayScene()
    {
        if(SceneManager.GetActiveScene().name == _mainMenuSceneName)
        {
            SceneManager.LoadScene(_gameplaySceneName);
        }
    }

    public void OpenDataScene()
    {
        if(SceneManager.GetActiveScene().name == _mainMenuSceneName)
        {
            SceneManager.LoadScene(_dataSceneName);
        }
    }

    protected void BackToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
