using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionButton : MonoBehaviour
{
    GameObject[] transmittionButtons;
    GameObject[] secrecyButtons;
    GameObject[] abilitiesButton;

    private void Start()
    {
        transmittionButtons = GameObject.FindGameObjectsWithTag("TransmissionButton");
        secrecyButtons = GameObject.FindGameObjectsWithTag("SecrecyButton");
        abilitiesButton = GameObject.FindGameObjectsWithTag("AbilitiesButton");

        //Debug.Log("transmittionButtons Length = " + transmittionButtons.Length);
        //Debug.Log("secrecyButtons Length = " + secrecyButtons.Length);
        //Debug.Log("abilitiesButton Length = " + abilitiesButton.Length);
    }

    public void PressButton()
    {
        if (transmittionButtons.Length > 0)
        {
            foreach (GameObject button in transmittionButtons)
            {
                button.SetActive(true);
                //Debug.Log("true");
            }
        }

        if (secrecyButtons.Length > 0)
        {
            foreach (GameObject button in secrecyButtons)
            {
                button.SetActive(false);
            }
        }

        if (abilitiesButton.Length > 0)
        {
            foreach (GameObject button in abilitiesButton)
            {
                button.SetActive(false);
            }
        }
    }
}
