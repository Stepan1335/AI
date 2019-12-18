using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ButtonInfrormationText")]
public class InformationForButtons : ScriptableObject
{
    [TextArea(14,10)] public new string informationAboutButton;
    public int pointCost = 0;
}

