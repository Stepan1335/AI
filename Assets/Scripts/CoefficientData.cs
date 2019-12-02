using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoefficientData
{
    #region Fields
    // Gadgets coefficients which get influence speed of spread    
    const float maxNumberOfUSBCoefficient = 0.03f;
    const float maxNumberOfPiratCoefficient = 0.03f;
    const float maxNumberOfEmailCoefficient = 0.03f;
    const float maxNumberOfSuspiciousSitesCoefficient = 0.03f;
    const float maxNumberOfMessengersCoefficient = 0.03f;
    const float maxNumberOfCrossPlatformCoefficient = 0.03f;

    // People coefficients which get influence speed of spread
    const float maxNumberOfAnimalCoefficient = 0.03f;
    const float maxNumberOfBirdsCoefficient = 0.03f;
    const float maxNumberOfAirCoefficient = 0.03f;
    const float maxNumberOfWaterCoefficient = 0.03f;
    const float maxNumberOfBloodCoefficient = 0.03f;

    #endregion

    #region Properties

    /// <summary>
    /// Get a max number of USB Coefficient 
    /// </summary>
    public static float MaxNumberOfUSBCoefficient
    {
        get { return maxNumberOfUSBCoefficient; }
    }

    /// <summary>
    /// Get a max number of Pirat Coefficient 
    /// </summary>
    public static float MaxNumberOfPiratCoefficient
    {
        get { return maxNumberOfPiratCoefficient; }
    }

    /// <summary>
    /// Get a max number of Email Coefficient 
    /// </summary>
    public static float MaxNumberOfEmailCoefficient
    {
        get { return maxNumberOfEmailCoefficient; }
    }

    /// <summary>
    /// Get a max number of Suspicious Sites Coefficient 
    /// </summary>
    public static float MaxNumberOfSuspiciousSitesCoefficient
    {
        get { return maxNumberOfSuspiciousSitesCoefficient; }
    }

    /// <summary>
    /// Get a max number of Messengers Coefficient 
    /// </summary>
    public static float MaxNumberOfMessengersCoefficient
    {
        get { return maxNumberOfMessengersCoefficient; }
    }

    /// <summary>
    /// Get a max number of Cross Platform Coefficient 
    /// </summary>
    public static float MaxNumberOfCrossPlatformCoefficient
    {
        get { return maxNumberOfCrossPlatformCoefficient; }
    }

    /// <summary>
    /// Get a max number of Animal Coefficient 
    /// </summary>
    public static float MaxNumberOfAnimalCoefficient
    {
        get { return maxNumberOfAnimalCoefficient; }
    }

    /// <summary>
    /// Get a max number of Birds Coefficient 
    /// </summary>
    public static float MaxNumberOfBirdsCoefficient
    {
        get { return maxNumberOfBirdsCoefficient; }
    }

    /// <summary>
    /// Get a max number of Air Coefficient 
    /// </summary>
    public static float MaxNumberOfAirCoefficient
    {
        get { return maxNumberOfAirCoefficient; }
    }

    /// <summary>
    /// Get a max number of Water Coefficient 
    /// </summary>
    public static float MaxNumberOfWaterCoefficient
    {
        get { return maxNumberOfWaterCoefficient; }
    }

    /// <summary>
    /// Get a max number of Blood Coefficient 
    /// </summary>
    public static float MaxNumberOfBloodCoefficient
    {
        get { return maxNumberOfBloodCoefficient; }
    }
    #endregion
}
