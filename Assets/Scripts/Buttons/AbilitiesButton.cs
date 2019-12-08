using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesButton : MonoBehaviour
{
    [SerializeField] GameObject[] transmittionButtons;
    [SerializeField] GameObject[] secrecyButtons;
    [SerializeField] GameObject[] abilitiesButton;


    public void PressButton()
    {    
        //Activate or deactivate a gameobject
        if (transmittionButtons.Length > 0)
        {
            foreach (GameObject button in transmittionButtons)
            {
                button.SetActive(false);
            }
        }
        //Activate or deactivate a gameobject
        if (secrecyButtons.Length > 0)
        {
            foreach (GameObject button in secrecyButtons)
            {
                button.SetActive(false);
            }
        }
        //Activate or deactivate a gameobject
        if (abilitiesButton.Length > 0)
        {
            foreach (GameObject button in abilitiesButton)
            {
                button.SetActive(true);
            }
        }
    }
}
