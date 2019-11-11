

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    // data about country

    //people
    public const int totalNumberOfPeople = 10000000;
    int currentNumberOfInfectedPeople = 0;
    int numberOfDeadPeople = 0;

    //Gadgents
    public const int totalNumberOfGadgets = 100000000;
    public int currentNumberOfInfectedGadgets = 0;

    // type of country 

    public bool pirat = true;
    public bool rich = false;
    bool infectedCountry = false;

    //Antivirus
    bool countryWorkOnAntivirus = false;
    bool antivirusDesigned = false;
    public float researchPotential = 1f;
    float howMuchofThatPotentialIsUsed = 0f;
    float currentProgressInAntivirusResearch = 0f;
    const float maxProgressInAntivirusResearch = 100f; 

    // data about virus
    int currentSecretiveness = 0;
    const int maxSecretiveness = 100;
    public float currentLethality = 0;




    // coefficients which get influence speed of spread
    public float currentUSBCoefficient = 0;
    const float maxNumberOfUSBCoefficient = 0.03f;

    public float currentPiratCoefficient = 0;
    const float maxNumberOfPiratCoefficient = 0.03f;

    public float currentEmailCoefficient = 0;
    const float maxNumberOfEmailCoefficient = 0.03f;

    public float currentSuspiciousSitesCoefficient = 0;
    const float maxNumberOfSuspiciousSitesCoefficient = 0.03f;

    public float currentMessengersCoefficient = 0;
    const float maxNumberOfMessengersCoefficient = 0.03f;

    public float currentCrossPlatformCoefficient = 0;
    const float maxNumberOfCrossPlatformCoefficient = 0.03f;

    // save for effectivity
    Animator animator;
    Timer timer;
    int timeToCountNextInteration = 1; 



    // Start is called before the first frame update
    void Start()
    {
        //Animator 
        animator = gameObject.GetComponent<Animator>();


        //Timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = timeToCountNextInteration;
        timer.Run();

        //Test about first start of the game
        infectedCountry = true;
        currentNumberOfInfectedGadgets = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            if (infectedCountry && currentNumberOfInfectedGadgets < totalNumberOfGadgets && !antivirusDesigned)
            {
                // count the how many gadgets get infected in next step of iteration

                // if number of infected people less than 20             
                if (currentNumberOfInfectedGadgets <= 20)
                {
                    //chanse to ger infected 
                    float chanceToGetInfected = Mathf.Clamp((float)currentNumberOfInfectedGadgets / 10 + currentCrossPlatformCoefficient + currentMessengersCoefficient
                        + currentSuspiciousSitesCoefficient + currentEmailCoefficient + currentPiratCoefficient + currentUSBCoefficient, 0, 1);

                    //if number of people less than 20 so it's only change to get ingected so next iteration of how many gadgets will be ingected on next step
                    //would be count by formula 
                    if (Random.value < chanceToGetInfected)
                    {
                        currentNumberOfInfectedGadgets = currentNumberOfInfectedGadgets + Random.Range(1, (int)Mathf.Clamp(currentNumberOfInfectedGadgets * (1 + currentCrossPlatformCoefficient
                            + currentMessengersCoefficient + currentSuspiciousSitesCoefficient + currentEmailCoefficient + currentPiratCoefficient + currentUSBCoefficient), 1, 20));
                    }
                }

                //if infected gadjets are more than 20 so it describes by function of the parabola
                else if (currentNumberOfInfectedGadgets > 20)
                {
                    float powerOfParabola = 1 + currentCrossPlatformCoefficient + currentMessengersCoefficient
                        + currentSuspiciousSitesCoefficient + currentEmailCoefficient + currentPiratCoefficient + currentUSBCoefficient;
                    currentNumberOfInfectedGadgets = Mathf.Clamp(currentNumberOfInfectedGadgets + Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedGadgets, powerOfParabola)),
                        1, totalNumberOfGadgets);

                }
                //Debug.Log(currentNumberOfInfectedGadgets);
                
            }


            // chance to get virus detected
            if (!countryWorkOnAntivirus && infectedCountry)
            {
                float coefficieantChanceToDetectedVirus = 0.01f;
                float chanceToDetectedVirus = coefficieantChanceToDetectedVirus + (float)currentNumberOfInfectedGadgets / (float)totalNumberOfGadgets - currentSecretiveness / maxSecretiveness;
                float random = Random.value;
                if (random < chanceToDetectedVirus)
                {
                    countryWorkOnAntivirus = true;
                }
                //test 
                //Debug.Log("random = " + random);
                //Debug.Log("chanceToDetectedVirus = " + chanceToDetectedVirus);
                //Debug.Log("countryWorkOnAntivirus = " + countryWorkOnAntivirus);
            }

            //working on antivirus 
            if (countryWorkOnAntivirus && !antivirusDesigned)
            {
                // count how much country use its research potensian it depends on number of infected gadgets
                float minPotentialIsUsed = 0.05f;
                howMuchofThatPotentialIsUsed = currentNumberOfInfectedGadgets / totalNumberOfGadgets + minPotentialIsUsed;
                
                // count the current progres in antivirus research 
                if (currentProgressInAntivirusResearch < maxProgressInAntivirusResearch)
                {
                    currentProgressInAntivirusResearch = Mathf.Clamp(currentProgressInAntivirusResearch + howMuchofThatPotentialIsUsed * researchPotential, 0, maxProgressInAntivirusResearch);
                }

                if (currentProgressInAntivirusResearch == maxProgressInAntivirusResearch)
                {
                    antivirusDesigned = true;
                }
                //test
                //Debug.Log("howMuchofThatPotentialIsUsed = " + howMuchofThatPotentialIsUsed);
                //Debug.Log("currentProgressInAntivirusResearch = " + currentProgressInAntivirusResearch);
                //Debug.Log("antivirusDesigned = " + antivirusDesigned);
            }

            //kill people when lethality more than zero 
            if (numberOfDeadPeople < totalNumberOfPeople)
            {
                numberOfDeadPeople = Mathf.Clamp(numberOfDeadPeople + Random.Range(0, (int)((float)totalNumberOfPeople * currentLethality)), 0, totalNumberOfPeople);
            }
            //test
            //Debug.Log("numberOfDeadPeople = " + numberOfDeadPeople);

            //restart the timer
            timer.Run();
        }
    }

    public void GetSelected()
    {
            animator.SetBool("Selected", true);
            //Debug.Log("true");
    }

    public void GetDeselected()
    {
        animator.SetBool("Selected", false);
        //Debug.Log("true");
    }

    /// <summary>
    /// change USB coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    void ChangeUSBCoefficient()
    {
        if (!rich && currentUSBCoefficient != maxNumberOfUSBCoefficient)
        {
            currentUSBCoefficient = maxNumberOfUSBCoefficient;
        }

        else if (!rich && currentUSBCoefficient == maxNumberOfUSBCoefficient)
        {
            currentUSBCoefficient = 0;
        }
    }

    /// <summary>
    /// change pirat coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    void ChangePiratCoefficient()
    {
        if (pirat && currentPiratCoefficient != maxNumberOfPiratCoefficient)
        {
            currentPiratCoefficient = maxNumberOfPiratCoefficient;
        }

        else if (pirat && currentPiratCoefficient == maxNumberOfPiratCoefficient)
        {
            currentPiratCoefficient = 0;
        }
    }

    /// <summary>
    /// change email coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    void ChangeEmailCoefficient()
    {
        if (currentEmailCoefficient != maxNumberOfEmailCoefficient)
        {
            currentEmailCoefficient = maxNumberOfEmailCoefficient;
        }

        else if (currentEmailCoefficient == maxNumberOfEmailCoefficient)
        {
            currentEmailCoefficient = 0;
        }
    }

    /// <summary>
    /// change Suspicious Sites coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    void ChangeSuspiciousSitesCoefficient()
    {
        if (currentSuspiciousSitesCoefficient != maxNumberOfSuspiciousSitesCoefficient)
        {
            currentSuspiciousSitesCoefficient = maxNumberOfSuspiciousSitesCoefficient;
        }

        else if (currentSuspiciousSitesCoefficient == maxNumberOfSuspiciousSitesCoefficient)
        {
            currentSuspiciousSitesCoefficient = 0;
        }
    }

    /// <summary>
    /// change Messenger coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    void ChangeMessengersCoefficient()
    {
        if (rich && currentMessengersCoefficient != maxNumberOfMessengersCoefficient)
        {
            currentMessengersCoefficient = maxNumberOfMessengersCoefficient;
        }

        else if (rich && currentMessengersCoefficient == maxNumberOfMessengersCoefficient)
        {
            currentMessengersCoefficient = 0;
        }
    }

    /// <summary>
    /// change CrossPlatform coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    void ChangeCrossPlatformCoefficient()
    {
        if (rich && currentCrossPlatformCoefficient != maxNumberOfCrossPlatformCoefficient)
        {
            currentCrossPlatformCoefficient = maxNumberOfCrossPlatformCoefficient;
        }

        else if (rich && currentCrossPlatformCoefficient == maxNumberOfCrossPlatformCoefficient)
        {
            currentCrossPlatformCoefficient = 0;
        }
    }
}
