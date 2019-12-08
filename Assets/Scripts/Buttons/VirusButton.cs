using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusButton : MonoBehaviour
{
    [SerializeField] GameObject virusControlPatel;
    [SerializeField] GameObject startButton;

    public void ButtonPressed()
    {
        if (virusControlPatel != null)
        {
            virusControlPatel.SetActive(true);
        }

        if (startButton != null)
        {
            startButton.GetComponent<TransmissionButton>().PressButton();
        }
        MouseCursor.CantControl(); // enable control in game
    }
}
