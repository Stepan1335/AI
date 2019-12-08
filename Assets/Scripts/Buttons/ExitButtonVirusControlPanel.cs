using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonVirusControlPanel : MonoBehaviour
{
    [SerializeField] GameObject virusControlPatel;

    public void ButtonPressed()
    {
        if (virusControlPatel != null)
        {
            virusControlPatel.SetActive(false);
        }

        MouseCursor.CanControl(); // able control in game
    }
}
