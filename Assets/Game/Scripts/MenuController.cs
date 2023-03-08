using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    static class Buttons
    {
        public static string LevelOneButton = "LevelOneButton";
        public static string LevelTwoButton = "LevelTwoButton";
    }
    
    static class Levels
    {
        public static string LevelOne = "LevelOne";
        public static string LevelTwo = "LevelTwo";
    }
    
    enum Screen
    {
        None,
        Main,
        Settings,
        LevelSelector
    }

    public CanvasGroup mainScreen;
    public CanvasGroup settingsScreen;
    public CanvasGroup levelSelectorScreen;
    
    void Start()
    {
        SetCurrentScreen(Screen.Main);
    }

    private void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Settings);
        Utility.SetCanvasGroupEnabled(levelSelectorScreen, screen == Screen.LevelSelector);
    }

    public void StartNewGame()
    {
        SetCurrentScreen(Screen.LevelSelector);
    }
    
    public void StartLevel()
    {
        var clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        if(Buttons.LevelOneButton == clickedButtonName)
        {
            SetCurrentScreen(Screen.None);
            SceneManager.LoadScene(Levels.LevelOne);
        }
        else if(Buttons.LevelTwoButton == clickedButtonName)
        {
            SetCurrentScreen(Screen.None);
            SceneManager.LoadScene(Levels.LevelTwo);
        }
        else
        {
            throw new Exception($"Не предусмотренная кнопка {clickedButtonName}");
        }
    }

    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Settings);
    }

    public void CloseSettings()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
