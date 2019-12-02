using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class USBCoefficient : MonoBehaviour
{
    [SerializeField] Sprite changeImage;
    public int pointsCost = 0;
    bool buttonPressed = false;

    public void ButtonGetDown()
    {
        if (World.Points >= pointsCost)
        {
            if (!buttonPressed)
            {
                GameObject[] countries;
                countries = GameObject.FindGameObjectsWithTag("Country");
                if (countries.Length > 0)
                {
                    foreach (GameObject country in countries)
                    {
                        country.GetComponent<Country>().ChangeUSBCoefficient();
                    }
                }
                gameObject.GetComponent<Image>().sprite = changeImage;
                buttonPressed = true;
            }
            World.subtractPoints(pointsCost);
        }
    }

}
