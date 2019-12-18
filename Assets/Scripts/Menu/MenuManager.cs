﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages navigation through the menu system
/// </summary>
public static class MenuManager
{
	/// <summary>
	/// Goes to the menu with the given name
	/// </summary>
	/// <param name="name">name of the menu to go to</param>
	public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Start:

                // go to DifficultyMenu scene
                SceneManager.LoadScene("GameplayScene");
                break;
            case MenuName.HighScore:

                // deactivate MainMenuCanvas and instantiate prefab
                GameObject mainMenuCanvas = GameObject.Find("MainMenu");
                if (mainMenuCanvas != null)
                {
                    mainMenuCanvas.SetActive(false);
                }
                Object.Instantiate(Resources.Load("HighScoreMenu"));
                break;
            case MenuName.Main:

                // go to MainMenu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:

                // instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.Help:

                //instantiate prefab
                Object.Instantiate(Resources.Load("HelpMenu"));
                break;
            case MenuName.Death:

                //instantiate prefab
                Object.Instantiate(Resources.Load("DeathMenu"));
                break;
            case MenuName.GameOver:

                // go to GameOver scene
                //instantiate prefab
                Object.Instantiate(Resources.Load("GameOver"));
                break;

        }
	}
}
