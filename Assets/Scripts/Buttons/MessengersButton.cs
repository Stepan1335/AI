using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessengersButton : MonoBehaviour
{
    //
    [SerializeField] Sprite changeImage;
    public int pointsCost = 0;
    bool buttonPressed = false;

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
                        country.GetComponent<Country>().ChangeMessengersCoefficient();
                    }
                }
                gameObject.GetComponent<Image>().sprite = changeImage; //change sprite 
                buttonPressed = true;
                World.subtractPoints(pointsCost);
            }
        }
    }
}
