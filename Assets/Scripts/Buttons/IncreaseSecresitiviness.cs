using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseSecresitiviness : MonoBehaviour
{
    //
    [SerializeField] Sprite changeImage;
    public int pointsCost = 0;
    bool buttonPressed = false;
    public GameObject[] buttonsWhatNeedTosetActiveWhenButtonIsPressed;
    [SerializeField] int addSecresitivinesNumber = 2;

    /// <summary>
    /// if button was pressed chage the coefficient chage the sprite(button would looks like pressed)
    /// </summary>
    public void ButtonGetDown()
    {
        if (World.Points >= pointsCost)
        {
            if (!buttonPressed) // button can be pressed only one time 
            {
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
