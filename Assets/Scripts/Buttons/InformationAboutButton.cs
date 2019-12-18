using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationAboutButton : MonoBehaviour
{
    [SerializeField] InformationForButtons information;

    Text informationText;
    Text pointCostText;

    [HideInInspector]
    public int pointsCost;
    int contstPointsCost;

    private void Start()
    {
        informationText = GameObject.FindGameObjectWithTag("ButtonInformalText").GetComponent<Text>();
        pointCostText = GameObject.FindGameObjectWithTag("CostText").GetComponent<Text>();
        contstPointsCost = information.pointCost;
    }

    private void Update()
    {
        UpdatePointsCost();
    }

    public void ButtonGetDown()
    {
        AudioManager.Play(AudioClipName.ButtonClick);

        informationText.text = information.informationAboutButton;
        pointCostText.text = "Costs " + pointsCost.ToString() + " points";
    }

    void UpdatePointsCost()
    {
        pointsCost = contstPointsCost + CoefficientData.AddingPointsCost;
    }
}
