using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Control information about current parameters like all infected gadget and people and dead people in all countries 
/// start the game 
/// Antivirus 
/// control points
/// </summary>
public class GameManager : MonoBehaviour
{
    bool gameStarted = false;
    static int points = 0;
    
    /// <summary>
    /// Points 
    /// </summary>
    public static int Points
    {
        get { return points;}
    }

    // Update is called once per frame
    void Update()
    {
        /*
           //Start the game
            if (!gameStarted && ControlInformalBar.SelectedCountry != null)
            {                
                gameStarted = true;
                ControlInformalBar.SelectedCountry.GetInfectedGadget(1);
                Debug.Log("Did " + gameStarted);            
            } */
    }

    /// <summary>
    /// Add a points
    /// </summary>
    /// <param name="howMuchToAdd"></param>
    public static void AddPoints( int howMuchToAdd)
    {
        points += howMuchToAdd;
    }

    /// <summary>
    /// Substract the points
    /// </summary>
    /// <param name="howMuchToSubtract"></param>
    public static void subtractPoints(int howMuchToSubtract)
    {
        points = Mathf.Clamp(points - howMuchToSubtract, 0, 100000);
    }
}
