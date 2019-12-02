using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationAboutButton : MonoBehaviour
{
    [SerializeField] InformationForButtons information;

    Text informationText;

    public void ButtonGetDown()
    {
        informationText = GameObject.FindGameObjectWithTag("ButtonInformalText").GetComponent<Text>();

        informationText.text = information.informationAboutButton;
    }
}
