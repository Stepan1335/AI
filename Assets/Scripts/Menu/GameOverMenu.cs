using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    //lifes support
    [SerializeField]
    Text textScoreGameObject;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {


        //change the amount of lifes
        scoreText = textScoreGameObject.GetComponent<Text>();
        scoreText.text = World.EndingText;
    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);

        //go to main menu
        MenuManager.GoToMenu(MenuName.Main);
    }
}
