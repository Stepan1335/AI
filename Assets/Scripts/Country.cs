using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    #region Field
    // data about country

    [SerializeField]
    string nameOfCountry = "Country";

    //people
    [SerializeField]
    int totalNumberOfPeople = 10000000;
    int currentNumberOfInfectedPeople = 0;
    int numberOfDeadPeople = 0;

    //Gadgents

    [SerializeField]
    int totalNumberOfGadgets = 100000000;

    int currentNumberOfInfectedGadgets = 0;

    // type of country 
       
    [SerializeField]
    bool pirat = true;

    [SerializeField]
    bool rich = false;

    bool infectedCountry = false;
    bool canInfectPeople = false;

    //Antivirus
    bool countryWorkOnAntivirus = false;
    bool antivirusDesigned = false;
    [SerializeField] float researchPotential = 1f;
    float howMuchofThatPotentialIsUsed = 0f;

    // data about virus
    int currentSecretiveness = 0;
    const int maxSecretiveness = 100;
    float currentLethality = 0;


    public List<Country> neighbours = new List<Country>();

    //Add Points system
    //Get extra points when number in infected Gadgets people or dead people became more then some interes from total number
    //Gadget
    bool firstInfectionOfGadgetInCountry = false;

    public float infectedWaveOneOfGadgetsgetPoints = 0.01f; //Percent of gadgets 
    bool infectedWaveOneOfGadgetsgetPointsBool = false;
    public int WaveOneOfGadgetsPointsAdd = 1;

    public float infectedWaveTwoOfGadgetsgetPoints = 0.05f; //Percent of gadgets 
    bool infectedWaveTwoOfGadgetsgetPointsBool = false;
    public int WaveTwoOfGadgetsPointsAdd = 2;

    public float infectedWaveThreeOfGadgetsgetPoints = 0.1f; //Percent of gadgets 
    bool infectedWaveThreeOfGadgetsgetPointsBool = false;
    public int WaveThreeOfGadgetsPointsAdd = 3;

    public float infectedWaveFourOfGadgetsgetPoints = 0.4f; //Percent of gadgets 
    bool infectedWaveFourOfGadgetsgetPointsBool = false;
    public int WaveFourOfGadgetsPointsAdd = 4;

    public float infectedWaveFiveOfGadgetsgetPoints = 0.7f; //Percent of gadgets 
    bool infectedWaveFiveOfGadgetsgetPointsBool = false;
    public int WaveFiveOfGadgetsPointsAdd = 5;

    public float infectedWaveSixOfGadgetsgetPoints = 1; //Percent of gadgets 
    bool infectedWaveSixOfGadgetsgetPointsBool = false;
    public int WaveSixOfGadgetsPointsAdd = 6;





    // Gadgets coefficients which get influence speed of spread
    public float currentUSBCoefficient = 0;
    float maxNumberOfUSBCoefficient = CoefficientData.MaxNumberOfUSBCoefficient;

    public float currentPiratCoefficient = 0;
    float maxNumberOfPiratCoefficient = CoefficientData.MaxNumberOfPiratCoefficient;

    public float currentEmailCoefficient = 0;
    float maxNumberOfEmailCoefficient = CoefficientData.MaxNumberOfEmailCoefficient;

    public float currentSuspiciousSitesCoefficient = 0;
    float maxNumberOfSuspiciousSitesCoefficient = CoefficientData.MaxNumberOfSuspiciousSitesCoefficient;

    public float currentMessengersCoefficient = 0;
    float maxNumberOfMessengersCoefficient = CoefficientData.MaxNumberOfMessengersCoefficient;

    public float currentCrossPlatformCoefficient = 0;
    float maxNumberOfCrossPlatformCoefficient = CoefficientData.MaxNumberOfCrossPlatformCoefficient;

    // People coefficients which get influence speed of spread
    public float currentAnimalCoefficient = 0;
    float maxNumberOfAnimalCoefficient = CoefficientData.MaxNumberOfAnimalCoefficient;

    public float currentBirdsCoefficient = 0;
    float maxNumberOfBirdsCoefficient = CoefficientData.MaxNumberOfBirdsCoefficient;

    public float currentAirCoefficient = 0;
    float maxNumberOfAirCoefficient = CoefficientData.MaxNumberOfAirCoefficient;

    public float currentWaterCoefficient = 0;
    float maxNumberOfWaterCoefficient = CoefficientData.MaxNumberOfWaterCoefficient;

    public float currentBloodCoefficient = 0;
    float maxNumberOfBloodCoefficient = CoefficientData.MaxNumberOfBloodCoefficient;
    
    // save for effectivity
    Animator animator;
    Timer timer;
    int timeToCountNextInteration = 1;

    //links
    ControlInformalBar controlInformalBarScript;
    World worldScript;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the position of the Country
    /// </summary>
    /// <value>position</value>
    public Vector2 Position
    {
        get { return transform.position; }
    }

    /// <summary>
    /// Get a total number of gadgets
    /// </summary>
    public int TotalNumberOfGadgets
    {
        get { return totalNumberOfGadgets; }
    }

    /// <summary>
    /// Get a current number of infected gadgets
    /// </summary>
    public int CurrentNumberOfInfectedGadgets
    {
        get { return currentNumberOfInfectedGadgets; }
    }

    /// <summary>
    /// Get a total number of people
    /// </summary>
    public int TotalNumberOfPeople
    {
        get { return totalNumberOfPeople; }
    }

    /// <summary>
    /// Get a current number of infected people
    /// </summary>
    public int CurrentNumberOfInfectedPeople
    {
        get { return currentNumberOfInfectedPeople; }
    }

    /// <summary>
    /// Get a current number of dead people
    /// </summary>
    public int CurrentNumberOfDeadPeople
    {
        get { return numberOfDeadPeople; }
    }


    /// <summary>
    /// Get a total number of used potensial in antivirus research
    /// </summary>
    public float HowMuchofThatPotentialIsUsed
    {
        get { return howMuchofThatPotentialIsUsed; }
    }

    /// <summary>
    /// Get a total number of research Potensian
    /// </summary>
    public float ResearchPotential
    {
        get { return researchPotential; }
    }

    /// <summary>
    /// Get name of the country
    /// </summary>
    public string CountryName
    {
        get { return nameOfCountry; }
    }

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        //links
        controlInformalBarScript = GameObject.FindGameObjectWithTag("InformalBar").GetComponent<ControlInformalBar>();
        worldScript = GameObject.FindGameObjectWithTag("World").GetComponent<World>();
        //Animator 
        animator = gameObject.GetComponent<Animator>();


        //Timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = timeToCountNextInteration;
        timer.Run();

        //Test about first start of the game
        //GetInfectedPeople(1);
        //GetInfectedGadget(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            // count the how many gadgets get infected in next step of iteration
            if (infectedCountry && currentNumberOfInfectedGadgets < totalNumberOfGadgets && !antivirusDesigned)
            {             
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

                AddPointsForGadget();
                //Debug.Log(currentNumberOfInfectedGadgets);
                
            }

            // count the how many people get infected in next step of iteration
            if (canInfectPeople && currentNumberOfInfectedPeople < totalNumberOfPeople && !antivirusDesigned)
            {              
                // if number of infected people less than 20             
                if (currentNumberOfInfectedPeople <= 20)
                {
                    //chanse to ger infected 
                    float chanceToGetInfected = Mathf.Clamp((float)currentNumberOfInfectedPeople / 10 + currentAnimalCoefficient + currentBirdsCoefficient
                        + currentAirCoefficient + currentWaterCoefficient + currentBloodCoefficient, 0, 1);

                    //if number of people less than 20 so it's only change to get ingected so next iteration of how many people will be ingected on next step
                    //would be count by formula 
                    if (Random.value < chanceToGetInfected)
                    {
                        currentNumberOfInfectedPeople = currentNumberOfInfectedPeople + Random.Range(1, (int)Mathf.Clamp(currentNumberOfInfectedPeople * (1 + currentAnimalCoefficient + currentBirdsCoefficient
                        + currentAirCoefficient + currentWaterCoefficient + currentBloodCoefficient), 1, 20));
                    }
                }

                //if infected people are more than 20 so it describes by function of the parabola
                else if (currentNumberOfInfectedPeople > 20)
                {
                    float powerOfParabola = 1 + currentAnimalCoefficient + currentBirdsCoefficient
                        + currentAirCoefficient + currentWaterCoefficient + currentBloodCoefficient;
                    currentNumberOfInfectedPeople = Mathf.Clamp(currentNumberOfInfectedPeople + Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedPeople, powerOfParabola)),
                        1, totalNumberOfPeople - numberOfDeadPeople);

                }
                //Debug.Log("current number of infected people = " + currentNumberOfInfectedPeople);
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
            if (countryWorkOnAntivirus && !worldScript.AntivirusDesigned)
            {
                // count how much country use its research potensian it depends on number of infected gadgets
                float minPotentialIsUsed = 0.05f;
                howMuchofThatPotentialIsUsed = currentNumberOfInfectedGadgets / totalNumberOfGadgets + minPotentialIsUsed;
                
                // count the current progres in antivirus research 
                if (worldScript.CurrentProgressInAntivirusResearch < worldScript.MaxProgressInAntivirusResearch)
                {
                    worldScript.UpdateAntivirusResearch(howMuchofThatPotentialIsUsed * researchPotential);
                }


                //test
                //Debug.Log("howMuchofThatPotentialIsUsed = " + howMuchofThatPotentialIsUsed);
                //Debug.Log("currentProgressInAntivirusResearch = " + currentProgressInAntivirusResearch);
                //Debug.Log("antivirusDesigned = " + antivirusDesigned);
            }

            //kill people when lethality more than zero 
            if (numberOfDeadPeople < totalNumberOfPeople)
            {
                int howMuchPeopleWillDie = Random.Range(0, (int)((float)totalNumberOfPeople * currentLethality));
                //increase number of infected people if people starts to die
                if (currentNumberOfInfectedPeople > 0 && howMuchPeopleWillDie != 0)
                {
                    currentNumberOfInfectedPeople = Mathf.Clamp(currentNumberOfInfectedPeople - (int)((float)currentNumberOfInfectedPeople * ((float)howMuchPeopleWillDie / ((float)totalNumberOfPeople - (float)numberOfDeadPeople))), 0, totalNumberOfPeople);
                    //Debug.Log("idd");
                }

                numberOfDeadPeople = Mathf.Clamp(numberOfDeadPeople + howMuchPeopleWillDie, 0, totalNumberOfPeople);


            }
            //test
            //Debug.Log("numberOfDeadPeople = " + numberOfDeadPeople);

            //Check the current Lethality
            currentLethality = worldScript.CurrentLethality;

            //restart the timer
            timer.Run();
        }
    }

    /// <summary>
    /// Add points when number in infected Gadgets became more then some interes from total number
    /// </summary>
    void AddPointsForGadget()
    {
        float fateOfinfectedGadgetFromTotal = (float)currentNumberOfInfectedGadgets / (float)totalNumberOfGadgets;

        if (currentNumberOfInfectedGadgets > 0 && !firstInfectionOfGadgetInCountry)
        {
            firstInfectionOfGadgetInCountry = true;
            World.AddPoints(1);
        }

        else if (fateOfinfectedGadgetFromTotal > infectedWaveOneOfGadgetsgetPoints && !infectedWaveOneOfGadgetsgetPointsBool)
        {
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveOneOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveOneOfGadgetsPointsAdd);
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal > infectedWaveTwoOfGadgetsgetPoints && !infectedWaveTwoOfGadgetsgetPointsBool)
        {
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveTwoOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveTwoOfGadgetsPointsAdd);
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal > infectedWaveThreeOfGadgetsgetPoints && !infectedWaveThreeOfGadgetsgetPointsBool)
        {
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveThreeOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveThreeOfGadgetsPointsAdd);
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal > infectedWaveFourOfGadgetsgetPoints && !infectedWaveFourOfGadgetsgetPointsBool)
        {
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveFourOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveFourOfGadgetsPointsAdd);
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal > infectedWaveFiveOfGadgetsgetPoints && !infectedWaveFiveOfGadgetsgetPointsBool)
        {
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveFiveOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveFiveOfGadgetsPointsAdd);
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal == infectedWaveSixOfGadgetsgetPoints && !infectedWaveSixOfGadgetsgetPointsBool)
        {
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveSixOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveSixOfGadgetsPointsAdd);
            Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }
    }

    /// <summary>
    /// become a prosses of spread of infection in gadgets   
    /// </summary>
    /// <param name="howManyGadgetToInfect"></param>
    public void GetInfectedGadget(int howManyGadgetToInfect)
    {
        infectedCountry = true;
        currentNumberOfInfectedGadgets = currentNumberOfInfectedGadgets + howManyGadgetToInfect;
    }

    /// <summary>
    /// become a prosses of spread of infection in people
    /// </summary>
    /// <param name="howManyGadgetToInfect"></param>
    public void GetInfectedPeople(int howManyPeopleToInfect)
    {
        canInfectPeople = true;
        currentNumberOfInfectedPeople += howManyPeopleToInfect;
    }

    public void GetSelected()
    {
            animator.SetBool("Selected", true);
            controlInformalBarScript.GetSellected(this);
            //Debug.Log("true");
    }

    public void GetDeselected()
    {
        animator.SetBool("Selected", false);
        controlInformalBarScript.GetDesellected();
        //Debug.Log("true");
    }

    /// <summary>
    /// change USB coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeUSBCoefficient()
    {
        if (!rich && currentUSBCoefficient != maxNumberOfUSBCoefficient)
        {
            currentUSBCoefficient = maxNumberOfUSBCoefficient;
        }

        else if (!rich && currentUSBCoefficient == maxNumberOfUSBCoefficient)
        {
            currentUSBCoefficient = 0;
        }
        //test
        //Debug.Log("USBCoefficients was chaged");
    }

    /// <summary>
    /// change pirat coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public  void ChangePiratCoefficient()
    {
        if (pirat && currentPiratCoefficient != maxNumberOfPiratCoefficient)
        {
            currentPiratCoefficient = maxNumberOfPiratCoefficient;
        }

        else if (pirat && currentPiratCoefficient == maxNumberOfPiratCoefficient)
        {
            currentPiratCoefficient = 0;
        }
        //test
        //Debug.Log("PirateCoefficients was chaged");
    }

    /// <summary>
    /// change email coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeEmailCoefficient()
    {
        if (currentEmailCoefficient != maxNumberOfEmailCoefficient)
        {
            currentEmailCoefficient = maxNumberOfEmailCoefficient;
        }

        else if (currentEmailCoefficient == maxNumberOfEmailCoefficient)
        {
            currentEmailCoefficient = 0;
        }
        //test
        //Debug.Log("EmailCoefficients was chaged");
    }

    /// <summary>
    /// change Suspicious Sites coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeSuspiciousSitesCoefficient()
    {
        if (currentSuspiciousSitesCoefficient != maxNumberOfSuspiciousSitesCoefficient)
        {
            currentSuspiciousSitesCoefficient = maxNumberOfSuspiciousSitesCoefficient;
        }

        else if (currentSuspiciousSitesCoefficient == maxNumberOfSuspiciousSitesCoefficient)
        {
            currentSuspiciousSitesCoefficient = 0;
        }
        //test
        //Debug.Log("SuspiciousSitesCoefficients was chaged");
    }

    /// <summary>
    /// change Messenger coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeMessengersCoefficient()
    {
        if (rich && currentMessengersCoefficient != maxNumberOfMessengersCoefficient)
        {
            currentMessengersCoefficient = maxNumberOfMessengersCoefficient;
        }

        else if (rich && currentMessengersCoefficient == maxNumberOfMessengersCoefficient)
        {
            currentMessengersCoefficient = 0;
        }
        //test
        //Debug.Log("MessengersCoefficients was chaged");
    }

    /// <summary>
    /// change CrossPlatform coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeCrossPlatformCoefficient()
    {
        if (rich && currentCrossPlatformCoefficient != maxNumberOfCrossPlatformCoefficient)
        {
            currentCrossPlatformCoefficient = maxNumberOfCrossPlatformCoefficient;
        }

        else if (rich && currentCrossPlatformCoefficient == maxNumberOfCrossPlatformCoefficient)
        {
            currentCrossPlatformCoefficient = 0;
        }
        //test
        //Debug.Log("CrossPlatformCoefficients was chaged");
    }


    /// <summary>
    /// change Animal coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeAnimalCoefficient()
    {
        if (currentAnimalCoefficient != maxNumberOfAnimalCoefficient)
        {
            currentAnimalCoefficient = maxNumberOfAnimalCoefficient;
        }

        else if (currentAnimalCoefficient == maxNumberOfAnimalCoefficient)
        {
            currentAnimalCoefficient = 0;
        }
        //test
        //Debug.Log("USBCoefficients was chaged");
    }

    /// <summary>
    /// change Bird coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeBirdCoefficient()
    {
        if (currentBirdsCoefficient != maxNumberOfBirdsCoefficient)
        {
            currentBirdsCoefficient = maxNumberOfBirdsCoefficient;
        }

        else if (currentBirdsCoefficient == maxNumberOfBirdsCoefficient)
        {
            currentBirdsCoefficient = 0;
        }
        //test
        //Debug.Log("USBCoefficients was chaged");
    }

    /// <summary>
    /// change Air coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeAirCoefficient()
    {
        if (currentAirCoefficient != maxNumberOfAirCoefficient)
        {
            currentAirCoefficient = maxNumberOfAirCoefficient;
        }

        else if (currentAirCoefficient == maxNumberOfAirCoefficient)
        {
            currentAirCoefficient = 0;
        }
        //test
        //Debug.Log("USBCoefficients was chaged");
    }

    /// <summary>
    /// change water coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeWaterCoefficient()
    {
        if (currentWaterCoefficient != maxNumberOfWaterCoefficient)
        {
            currentWaterCoefficient = maxNumberOfWaterCoefficient;
        }

        else if (currentWaterCoefficient == maxNumberOfWaterCoefficient)
        {
            currentWaterCoefficient = 0;
        }
        //test
        //Debug.Log("USBCoefficients was chaged");
    }

    /// <summary>
    /// change Blood coefficient
    /// count by himself in what way to change coefficient
    /// </summary>
    public void ChangeBloodCoefficient()
    {
        if (currentBloodCoefficient != maxNumberOfBloodCoefficient)
        {
            currentBloodCoefficient = maxNumberOfBloodCoefficient;
        }

        else if (currentBloodCoefficient == maxNumberOfBloodCoefficient)
        {
            currentBloodCoefficient = 0;
        }
        //test
        //Debug.Log("USBCoefficients was chaged");
    }
    #endregion
}
