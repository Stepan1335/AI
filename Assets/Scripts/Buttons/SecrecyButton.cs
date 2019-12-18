using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecrecyButton : MonoBehaviour
{
    [SerializeField] GameObject[] transmittionButtons;
    [SerializeField] GameObject[] secrecyButtons;
    [SerializeField] GameObject[] abilitiesButton;

    private void Start()
    {
        //Debug.Log("transmittionButtons Length = " + transmittionButtons.Length);
        //Debug.Log("secrecyButtons Length = " + secrecyButtons.Length);
        //Debug.Log("abilitiesButton Length = " + abilitiesButton.Length);
    }

    public void PressButton()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        if (transmittionButtons.Length > 0)
        {
            foreach (GameObject button in transmittionButtons)
            {
                button.SetActive(false);
            }
        }

        if (secrecyButtons.Length > 0)
        {
            foreach (GameObject button in secrecyButtons)
            {
                button.SetActive(true);
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
