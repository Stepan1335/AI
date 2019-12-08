using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestructureCodeButton : MonoBehaviour
{
    //
    [SerializeField] Sprite changeImage;
    public int pointsCost = 0;
    bool buttonPressed = false;
    public GameObject[] buttonsWhatNeedTosetActiveWhenButtonIsPressed;
    [SerializeField] int reduceAnvitirusResearchOn = 2;

    /// <summary>
    /// if button was pressed chage the coefficient chage the sprite(button would looks like pressed)
    /// </summary>
    public void ButtonGetDown()
    {
        if (World.Points >= pointsCost)
        {
            if (!buttonPressed) // button can be pressed only one time 
            {
                World.reduceProgressOfAntivirusResearch(reduceAnvitirusResearchOn);
                gameObject.GetComponent<Image>().sprite = changeImage; //change sprite 
                buttonPressed = true;
                World.subtractPoints(pointsCost);

                if (buttonsWhatNeedTosetActiveWhenButtonIsPressed.Length > 0) //Set active buttons when button was pressed
                {
                    foreach (GameObject button in buttonsWhatNeedTosetActiveWhenButtonIsPressed)
                    {
                        button.SetActive(true);
                    }
                }
            }
        }
    }
}
