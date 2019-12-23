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
    long totalNumberOfPeople = 10000000;
    long currentNumberOfInfectedPeople = 0;
    long numberOfDeadPeople = 0;
    int K0People = 100; // a threshold that separates the probability of transmission of the virus and its 100% transmission 

    //Gadgents

    [SerializeField]
    long totalNumberOfGadgets = 100000000;

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
    int K0Gadget = 100; // a threshold that separates the probability of transmission of the virus and its 100% transmission 

    //nanobots
    float decreaseResearchPotential = 1;


    public List<Country> neighbours = new List<Country>();

    //Add Points system

    bool firstInfectionOfGadgetInCountry = false;

    float infectedWaveOneOfGadgetsgetPoints = 0.00001f; //Percent of gadgets 
    bool infectedWaveOneOfGadgetsgetPointsBool = false;
    int WaveOneOfGadgetsPointsAdd = 2;

    float infectedWaveTwoOfGadgetsgetPoints = 0.00005f; //Percent of gadgets 
    bool infectedWaveTwoOfGadgetsgetPointsBool = false;
    int WaveTwoOfGadgetsPointsAdd = 3;

    float infectedWaveThreeOfGadgetsgetPoints = 0.0001f; //Percent of gadgets 
    bool infectedWaveThreeOfGadgetsgetPointsBool = false;
    int WaveThreeOfGadgetsPointsAdd = 3;

    float infectedWaveFourOfGadgetsgetPoints = 0.1f; //Percent of gadgets 
    bool infectedWaveFourOfGadgetsgetPointsBool = false;
    int WaveFourOfGadgetsPointsAdd = 1;

    float infectedWaveFiveOfGadgetsgetPoints = 0.5f; //Percent of gadgets 
    bool infectedWaveFiveOfGadgetsgetPointsBool = false;
    int WaveFiveOfGadgetsPointsAdd = 1;

    float infectedWaveSixOfGadgetsgetPoints = 1; //Percent of gadgets 
    bool infectedWaveSixOfGadgetsgetPointsBool = false;
    int WaveSixOfGadgetsPointsAdd = 1;

    //infected people

    float infectedWaveOneOfInfectedPeoplegetPoints = 0.0001f; //Percent of InfectedPeople
    bool infectedWaveOneOfInfectedPeoplegetPointsBool = false;
    int WaveOneOfInfectedPeoplePointsAdd = 1;

    float infectedWaveTwoOfInfectedPeoplegetPoints = 0.0005f; //Percent of InfectedPeople
    bool infectedWaveTwoOfInfectedPeoplegetPointsBool = false;
    int WaveTwoOfInfectedPeoplePointsAdd = 1;

    float infectedWaveThreeOfInfectedPeoplegetPoints = 0.01f; //Percent of InfectedPeople
    bool infectedWaveThreeOfInfectedPeoplegetPointsBool = false;
    int WaveThreeOfInfectedPeoplePointsAdd = 2;

    float infectedWaveFourOfInfectedPeoplegetPoints = 0.1f; //Percent of InfectedPeople
    bool infectedWaveFourOfInfectedPeoplegetPointsBool = false;
    int WaveFourOfInfectedPeoplePointsAdd = 2;

    float infectedWaveFiveOfInfectedPeoplegetPoints = 0.5f; //Percent of InfectedPeople 
    bool infectedWaveFiveOfInfectedPeoplegetPointsBool = false;
    int WaveFiveOfInfectedPeoplePointsAdd = 2;

    //Dead people 

    float infectedWaveOneOfDeadPeoplegetPoints = 0.001f; //Percent of DeadPeople
    bool infectedWaveOneOfDeadPeoplegetPointsBool = false;
    int WaveOneOfDeadPeoplePointsAdd = 1;

    float infectedWaveTwoOfDeadPeoplegetPoints = 0.005f; //Percent of DeadPeople 
    bool infectedWaveTwoOfDeadPeoplegetPointsBool = false;
    int WaveTwoOfDeadPeoplePointsAdd = 1;

    float infectedWaveThreeOfDeadPeoplegetPoints = 0.1f; //Percent of DeadPeople
    bool infectedWaveThreeOfDeadPeoplegetPointsBool = false;
    int WaveThreeOfDeadPeoplePointsAdd = 1;

    float infectedWaveFourOfDeadPeoplegetPoints = 0.4f; //Percent of DeadPeople
    bool infectedWaveFourOfDeadPeoplegetPointsBool = false;
    int WaveFourOfDeadPeoplePointsAdd = 2;

    float infectedWaveFiveOfDeadPeoplegetPoints = 0.7f; //Percent of DeadPeople
    bool infectedWaveFiveOfDeadPeoplegetPointsBool = false;
    int WaveFiveOfDeadPeopleointsAdd = 3;

    // Gadgets coefficients which get influence speed of spread
    float currentUSBCoefficient = 0;
    float maxNumberOfUSBCoefficient = CoefficientData.MaxNumberOfUSBCoefficient;

    float currentPiratCoefficient = 0;
    float maxNumberOfPiratCoefficient = CoefficientData.MaxNumberOfPiratCoefficient;

    float currentEmailCoefficient = 0;
    float maxNumberOfEmailCoefficient = CoefficientData.MaxNumberOfEmailCoefficient;

    float currentSuspiciousSitesCoefficient = 0;
    float maxNumberOfSuspiciousSitesCoefficient = CoefficientData.MaxNumberOfSuspiciousSitesCoefficient;

    float currentMessengersCoefficient = 0;
    float maxNumberOfMessengersCoefficient = CoefficientData.MaxNumberOfMessengersCoefficient;

    float currentCrossPlatformCoefficient = 0;
    float maxNumberOfCrossPlatformCoefficient = CoefficientData.MaxNumberOfCrossPlatformCoefficient;

    // People coefficients which get influence speed of spread
    float currentAnimalCoefficient = 0;
    float maxNumberOfAnimalCoefficient = CoefficientData.MaxNumberOfAnimalCoefficient;

    float currentBirdsCoefficient = 0;
    float maxNumberOfBirdsCoefficient = CoefficientData.MaxNumberOfBirdsCoefficient;

    float currentAirCoefficient = 0;
    float maxNumberOfAirCoefficient = CoefficientData.MaxNumberOfAirCoefficient;

    float currentWaterCoefficient = 0;
    float maxNumberOfWaterCoefficient = CoefficientData.MaxNumberOfWaterCoefficient;

    float currentBloodCoefficient = 0;
    float maxNumberOfBloodCoefficient = CoefficientData.MaxNumberOfBloodCoefficient;

    //Position for corecting coordinates in some countries
    [SerializeField] GameObject position;

    
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
        get { if (position != null)
            {
                return position.transform.position;
            }
            else
            {
                return transform.position;
            }
        }
    }

    /// <summary>
    /// Get a total number of gadgets
    /// </summary>
    public long TotalNumberOfGadgets
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
    public long TotalNumberOfPeople
    {
        get { return totalNumberOfPeople; }
    }

    /// <summary>
    /// Get a current number of infected people
    /// </summary>
    public long CurrentNumberOfInfectedPeople
    {
        get { return currentNumberOfInfectedPeople; }
    }

    /// <summary>
    /// Get a current number of dead people
    /// </summary>
    public long CurrentNumberOfDeadPeople
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
                // if number of infected people less than k0            
                if (currentNumberOfInfectedGadgets <= K0Gadget)
                {
                    //chanse to ger infected 
                    float chanceToGetInfected = Mathf.Clamp((float)currentNumberOfInfectedGadgets / 20 + (currentCrossPlatformCoefficient + currentMessengersCoefficient
                        + currentSuspiciousSitesCoefficient + currentEmailCoefficient + currentPiratCoefficient + currentUSBCoefficient) * 30, 0, 1);

                    //if number of people less than k0 so it's only change to get ingected so next iteration of how many gadgets will be ingected on next step
                    //would be count by formula 
                    if (Random.value < chanceToGetInfected)
                    {
                        currentNumberOfInfectedGadgets = currentNumberOfInfectedGadgets + Random.Range(1, (int)Mathf.Clamp(currentNumberOfInfectedGadgets * (1 + currentCrossPlatformCoefficient
                            + currentMessengersCoefficient + currentSuspiciousSitesCoefficient + currentEmailCoefficient + currentPiratCoefficient + currentUSBCoefficient), 1, K0Gadget));
                    }
                }

                //if infected gadjets are more than 20 so it describes by function of the parabola
                else if (currentNumberOfInfectedGadgets > K0Gadget)
                {
                    float powerOfParabola = 1 + currentCrossPlatformCoefficient + currentMessengersCoefficient
                        + currentSuspiciousSitesCoefficient + currentEmailCoefficient + currentPiratCoefficient + currentUSBCoefficient;
                    long addingNumberOfInfectedGadgets1 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedGadgets / 25, powerOfParabola));// i need it constuction because I guess if number out of renge of int it become 0
                    long addingNumberOfInfectedGadgets2 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedGadgets / 25, powerOfParabola));
                    long addingNumberOfInfectedGadgets3 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedGadgets / 25, powerOfParabola));
                    long addingNumberOfInfectedGadgets4 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedGadgets / 25, powerOfParabola));
                    long addingNumberOfInfectedGadgets5 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedGadgets / 25, powerOfParabola));

                    currentNumberOfInfectedGadgets = (int)Mathf.Clamp(currentNumberOfInfectedGadgets + addingNumberOfInfectedGadgets1 + addingNumberOfInfectedGadgets2 + addingNumberOfInfectedGadgets3 
                        + addingNumberOfInfectedGadgets4 + addingNumberOfInfectedGadgets5, 1, totalNumberOfGadgets);

                }

                AddPointsForGadget();
                //Debug.Log(currentNumberOfInfectedGadgets);
                
            }

            // count the how many people get infected in next step of iteration
            if (canInfectPeople && currentNumberOfInfectedPeople < totalNumberOfPeople - numberOfDeadPeople && !antivirusDesigned)
            {              
                // if number of infected people less than k0            
                if (currentNumberOfInfectedPeople <= K0People)
                {
                    //chanse to ger infected 
                    float chanceToGetInfected = Mathf.Clamp((float)currentNumberOfInfectedPeople / 10 + (currentAnimalCoefficient + currentBirdsCoefficient
                        + currentAirCoefficient + currentWaterCoefficient + currentBloodCoefficient) * 20, 0, 1);

                    //if number of people less than k0 so it's only change to get ingected so next iteration of how many people will be ingected on next step
                    //would be count by formula 
                    if (Random.value < chanceToGetInfected)
                    {
                        currentNumberOfInfectedPeople = currentNumberOfInfectedPeople + Random.Range(1, (int)Mathf.Clamp(currentNumberOfInfectedPeople * (1 + currentAnimalCoefficient + currentBirdsCoefficient
                        + currentAirCoefficient + currentWaterCoefficient + currentBloodCoefficient), 1, K0People));
                    }
                }

                //if infected people are more than 20 so it describes by function of the parabola
                else if (currentNumberOfInfectedPeople > K0People)
                {
                    float powerOfParabola = 1 + currentAnimalCoefficient + currentBirdsCoefficient
                        + currentAirCoefficient + currentWaterCoefficient + currentBloodCoefficient;
                    long addingInfectedPeople1 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedPeople / 25, powerOfParabola)); // i need it constuction because I guess if number out of renge of int it become 0
                    long addingInfectedPeople2 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedPeople / 25, powerOfParabola));
                    long addingInfectedPeople3 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedPeople / 25, powerOfParabola));
                    long addingInfectedPeople4 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedPeople / 25, powerOfParabola));
                    long addingInfectedPeople5 = Random.Range(10, (int)Mathf.Pow(currentNumberOfInfectedPeople / 25, powerOfParabola));
                    currentNumberOfInfectedPeople = (int)Mathf.Clamp(currentNumberOfInfectedPeople + addingInfectedPeople1 + addingInfectedPeople2 + addingInfectedPeople3 + addingInfectedPeople4 + addingInfectedPeople5,
                        0, Mathf.Clamp(totalNumberOfPeople - numberOfDeadPeople, 0, totalNumberOfPeople));
                }
                AddPointsForInfectedPeople();
                //Debug.Log("current number of infected people = " + currentNumberOfInfectedPeople);
            }
            // chance to get virus detected
            if (!countryWorkOnAntivirus && infectedCountry)
            {
                float coefficieantChanceToDetectedVirus = 0.005f;
                float chanceToDetectedVirus = Mathf.Clamp(coefficieantChanceToDetectedVirus + (float)currentNumberOfInfectedGadgets / (float)totalNumberOfGadgets - currentSecretiveness / maxSecretiveness, 0, 1);
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
            if (countryWorkOnAntivirus && !worldScript.AntivirusDesigned && numberOfDeadPeople != totalNumberOfPeople)
            {
                // count how much country use its research potensian it depends on number of infected gadgets
                float minPotentialIsUsed = 0.005f;
                howMuchofThatPotentialIsUsed = Mathf.Clamp(((float)currentNumberOfInfectedGadgets / ((float)totalNumberOfGadgets * (float)decreaseResearchPotential)) * (1 - (float)currentSecretiveness / (float)maxSecretiveness) 
                    - (float)numberOfDeadPeople / (float)totalNumberOfPeople  + minPotentialIsUsed, 0 ,1); //the more secretiveness the hard to develop antivirus, The more people are dead the hard to develop a antivirus
                
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
                    currentNumberOfInfectedPeople = (int)Mathf.Clamp(currentNumberOfInfectedPeople - (int)((float)currentNumberOfInfectedPeople * ((float)howMuchPeopleWillDie / ((float)totalNumberOfPeople - (float)numberOfDeadPeople))), 0, totalNumberOfPeople);
                    //Debug.Log("idd");
                }

                numberOfDeadPeople = (int)Mathf.Clamp(numberOfDeadPeople + howMuchPeopleWillDie, 0, totalNumberOfPeople);
                AddPointsForDeadPeople();

            }
            //test
            //Debug.Log("numberOfDeadPeople = " + numberOfDeadPeople);

            //check if in country all people are dead so it means that noone can be infected
            if (numberOfDeadPeople >= totalNumberOfPeople)
            {
                currentNumberOfInfectedPeople = 0;
                canInfectPeople = false;
            }

            //Check the current Lethality
            currentLethality = worldScript.CurrentLethality;

            //restart the timer
            timer.Run();
        }
    }

    /// <summary>
    /// Change Decrease Research Potential Coefficient
    /// consider a current number of infected people
    /// </summary>
    /// <param name="number"></param>
    public void ChangeDecreaseResearchPotentialCoefficient( float number)
    {
        decreaseResearchPotential = 1 + ((float)currentNumberOfInfectedGadgets / (float)totalNumberOfPeople) * number;

        //test
        //Debug.Log("decreaseResearchPotential = " + decreaseResearchPotential + "  did ");
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
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveOneOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveOneOfGadgetsPointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal > infectedWaveTwoOfGadgetsgetPoints && !infectedWaveTwoOfGadgetsgetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveTwoOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveTwoOfGadgetsPointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal > infectedWaveThreeOfGadgetsgetPoints && !infectedWaveThreeOfGadgetsgetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveThreeOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveThreeOfGadgetsPointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal > infectedWaveFourOfGadgetsgetPoints && !infectedWaveFourOfGadgetsgetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveFourOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveFourOfGadgetsPointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal > infectedWaveFiveOfGadgetsgetPoints && !infectedWaveFiveOfGadgetsgetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveFiveOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveFiveOfGadgetsPointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }

        else if(fateOfinfectedGadgetFromTotal == infectedWaveSixOfGadgetsgetPoints && !infectedWaveSixOfGadgetsgetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
            infectedWaveSixOfGadgetsgetPointsBool = true;
            World.AddPoints(WaveSixOfGadgetsPointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfinfectedGadgetFromTotal = " + fateOfinfectedGadgetFromTotal);
        }
    }

    /// <summary>
    /// Add points when number in infected people became more then some interes from total number
    /// </summary>
    void AddPointsForInfectedPeople()
    {
        float fateOfInfectedPeopleFromTotal = (float)currentNumberOfInfectedPeople / (float)totalNumberOfPeople;

        if (fateOfInfectedPeopleFromTotal > infectedWaveOneOfInfectedPeoplegetPoints && !infectedWaveOneOfInfectedPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
            infectedWaveOneOfInfectedPeoplegetPointsBool = true;
            World.AddPoints(WaveOneOfInfectedPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
        }

        else if (fateOfInfectedPeopleFromTotal > infectedWaveTwoOfInfectedPeoplegetPoints && !infectedWaveTwoOfInfectedPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
            infectedWaveTwoOfInfectedPeoplegetPointsBool = true;
            World.AddPoints(WaveTwoOfInfectedPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
        }

        else if (fateOfInfectedPeopleFromTotal > infectedWaveThreeOfInfectedPeoplegetPoints && !infectedWaveThreeOfInfectedPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
            infectedWaveThreeOfInfectedPeoplegetPointsBool = true;
            World.AddPoints(WaveThreeOfInfectedPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
        }

        else if (fateOfInfectedPeopleFromTotal > infectedWaveFourOfInfectedPeoplegetPoints && !infectedWaveFourOfInfectedPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
            infectedWaveFourOfInfectedPeoplegetPointsBool = true;
            World.AddPoints(WaveFourOfInfectedPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
        }

        else if (fateOfInfectedPeopleFromTotal > infectedWaveFiveOfInfectedPeoplegetPoints && !infectedWaveFiveOfInfectedPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
            infectedWaveFiveOfInfectedPeoplegetPointsBool = true;
            World.AddPoints(WaveFiveOfInfectedPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfInfectedPeopleFromTotal = " + fateOfInfectedPeopleFromTotal);
        }
    }

    /// <summary>
    /// Add points when number in dead people became more then some interes from total number
    /// </summary>
    void AddPointsForDeadPeople()
    {
        float fateOfDeadPeopleFromTotal = (float)numberOfDeadPeople / (float)totalNumberOfPeople;

        if (fateOfDeadPeopleFromTotal > infectedWaveOneOfDeadPeoplegetPoints && !infectedWaveOneOfDeadPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
            infectedWaveOneOfDeadPeoplegetPointsBool = true;
            World.AddPoints(WaveOneOfDeadPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
        }

        else if (fateOfDeadPeopleFromTotal > infectedWaveTwoOfDeadPeoplegetPoints && !infectedWaveTwoOfDeadPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
            infectedWaveTwoOfDeadPeoplegetPointsBool = true;
            World.AddPoints(WaveTwoOfDeadPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
        }

        else if (fateOfDeadPeopleFromTotal > infectedWaveThreeOfDeadPeoplegetPoints && !infectedWaveThreeOfDeadPeoplegetPointsBool)
        {
           //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
            infectedWaveThreeOfDeadPeoplegetPointsBool = true;
            World.AddPoints(WaveThreeOfDeadPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
        }

        else if (fateOfDeadPeopleFromTotal > infectedWaveFourOfDeadPeoplegetPoints && !infectedWaveFourOfDeadPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
            infectedWaveFourOfDeadPeoplegetPointsBool = true;
            World.AddPoints(WaveFourOfDeadPeoplePointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
        }

        else if (fateOfDeadPeopleFromTotal > infectedWaveFiveOfDeadPeoplegetPoints && !infectedWaveFiveOfDeadPeoplegetPointsBool)
        {
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
            infectedWaveFiveOfDeadPeoplegetPointsBool = true;
            World.AddPoints(WaveFiveOfDeadPeopleointsAdd);
            //Debug.Log("Points = " + World.Points + " fateOfDeadPeopleFromTotal = " + fateOfDeadPeopleFromTotal);
        }
    }

    /// <summary>
    /// become a prosses of spread of infection in gadgets   
    /// </summary>
    /// <param name="howManyGadgetToInfect"></param>
    public void GetInfectedGadget(int howManyGadgetToInfect)
    {
        infectedCountry = true;
        currentNumberOfInfectedGadgets = (int)Mathf.Clamp(currentNumberOfInfectedGadgets + howManyGadgetToInfect, 0 , totalNumberOfGadgets); 
    }

    /// <summary>
    /// become a prosses of spread of infection in people
    /// </summary>
    /// <param name="howManyGadgetToInfect"></param>
    public void GetInfectedPeople(int howManyPeopleToInfect)
    {
        canInfectPeople = true;
        currentNumberOfInfectedPeople = (int)Mathf.Clamp(currentNumberOfInfectedPeople + howManyPeopleToInfect, 0, totalNumberOfPeople);

        //test
        //Debug.Log("infected people = " + CurrentNumberOfInfectedPeople);
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
    /// Add a secretiveness 
    /// </summary>
    /// <param name="number"></param>
    public void AddSecretiveness(int number)
    {
        if (currentSecretiveness < maxSecretiveness)
        {
            currentSecretiveness = Mathf.Clamp(currentSecretiveness + number, 0, maxSecretiveness );
            //test
            //Debug.Log("currentSecretiveness = " + currentSecretiveness);
        }
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
        //Debug.Log("AnimalCoefficients was chaged");
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
        //Debug.Log("BirdCoefficients was chaged");
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
        //Debug.Log("AirCoefficients was chaged");
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
        //Debug.Log("WaterCoefficients was chaged");
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
        //Debug.Log("BloodCoefficients was chaged " + currentBloodCoefficient);
    }
    #endregion
}
