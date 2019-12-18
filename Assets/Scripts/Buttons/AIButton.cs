using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIButton : MonoBehaviour
{
    //
    [SerializeField] Sprite changeImage;
    int pointsCost = 0;
    public bool buttonPressed = false;
    public GameObject[] buttonsWhatNeedTosetActiveWhenButtonIsPressed;

    /// <summary>
    /// if button was pressed chage the coefficient chage the sprite(button would looks like pressed)
    /// </summary>
    public void ButtonGetDown()
    {
        pointsCost = transform.parent.GetComponentInChildren<InformationAboutButton>().pointsCost; //find out how much this button will be cost
        //Debug.Log("pointsCost = " + pointsCost);
        if (World.Points >= pointsCost)
        {
            if (!buttonPressed) // button can be pressed only one time 
            {
                CoefficientData.AddingAdditionalPoints(1);
                AudioManager.Play(AudioClipName.ButtonClick);
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
