using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseSecresitivinessLevel2 : MonoBehaviour
{
    //
    [SerializeField] Sprite changeImage;
    int pointsCost = 0;
    public bool buttonPressed = false;
    [SerializeField] int addSecresitivinesNumber = 2;
    public GameObject[] buttonsWhatNeedTosetActiveWhenButtonIsPressed;
    //buttons that need to be checked before unlock next one
    public GameObject[] checkButtons;

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
                GameObject[] countries;
                countries = GameObject.FindGameObjectsWithTag("Country");
                if (countries.Length > 0)
                {
                    foreach (GameObject country in countries)
                    {
                        country.GetComponent<Country>().AddSecretiveness(addSecresitivinesNumber);
                    }
                }
                gameObject.GetComponent<Image>().sprite = changeImage; //change sprite 
                buttonPressed = true;
                World.subtractPoints(pointsCost);

                //if this coefficient equal to length of array unlock next button if that buttons was pressed
                int lengthCheck = 0;
                if (checkButtons.Length > 0)
                {
                    foreach (GameObject button in checkButtons)
                    {
                        if (button.GetComponent<IncreaseSecresitivinessLevel2>().buttonPressed)
                        {
                            lengthCheck++;
                        }
                    }
                    //test
                    //Debug.Log("checkButtons.Length = " + checkButtons.Length + "lengthCheck = " + lengthCheck);
                }

                if (lengthCheck == checkButtons.Length)
                {
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
}
