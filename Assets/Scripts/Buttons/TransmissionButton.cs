using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionButton : MonoBehaviour
{
    [SerializeField] GameObject[] transmittionButtons;
    [SerializeField] GameObject[] secrecyButtons;
    [SerializeField] GameObject[] abilitiesButton;

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
