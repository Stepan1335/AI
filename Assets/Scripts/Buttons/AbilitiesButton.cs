﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesButton : MonoBehaviour
{
    GameObject[] transmittionButtons;
    GameObject[] secrecyButtons;
    GameObject[] abilitiesButton;

    private void Start()
    {
        //look for referenses for all buttons
        transmittionButtons = GameObject.FindGameObjectsWithTag("TransmissionButton");
        secrecyButtons = GameObject.FindGameObjectsWithTag("SecrecyButton");
        abilitiesButton = GameObject.FindGameObjectsWithTag("AbilitiesButton");

        //Debug.Log("transmittionButtons Length = " + transmittionButtons.Length);
        //Debug.Log("secrecyButtons Length = " + secrecyButtons.Length);
        //Debug.Log("abilitiesButton Length = " + abilitiesButton.Length);
    }

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
