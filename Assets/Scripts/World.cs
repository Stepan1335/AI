using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Count the total informarion about all countries like infected gadgets and people and dead people
/// start the game
/// Control Antivitus
/// Points
/// creating packages between countries
/// </summary>
public class World : MonoBehaviour
{
    [SerializeField]
    GameObject packegePrefab;
    #region Fields
    GameObject[] countriesGameObj;
    List<Country> countriesScripts = new List<Country>();

    //parameters of the world
    long currentNumberOfInfectedGadgets = 0;
    long totalNumberOfGadgets = 0;

    long currentNumberOfInfectedPeople = 0;
    long currentNumberofDeadPeople = 0;
    long totalNumberOfPeople = 0;
    public float minChanseForPackageToBeInfected = 0.05f;

    static float currentLethality = 0;

    string nameOfWorld = "World";

    //flag control game start
    bool gameStarted = false;
    bool endGame = false;
    static bool peoplePrayOnAI = false; //flag needs for ending game and show player the right ending
    static bool matrixCreation = false;

    //Points
    static int points = 0;

    //Antivirus
    bool antivirusDesigned = false;
    float researchPotential = 0f;
    float howMuchofThatPotentialIsUsed = 0f;
    static float currentProgressInAntivirusResearch = 0f;
    const float maxProgressInAntivirusResearch = 100f;

    //Timer
    Timer timerUpdateInformation;
    float timerDurationUpdateInfromation = 1;

    //Activate AICreat button when number of infected gadgets become more that some interes
    [SerializeField] GameObject AIButton;
    [SerializeField] float interesToActivateAIButton = 0.3f;
    bool aIButtonCreated = false;
    [TextArea(10, 3)] static string endingText = " ";

    /// <summary>
    /// Creating a system what will send packeges to different countries
    /// </summary>
    //Graph
    Graph<Country> graph;

    //Timer
    Timer timerCreatingNewPackeges;
    public float timerDurationCreatingNewPackeges = 10;

    //need for creating sending packeger system
    GraphNode<Country> lastSelectedCountry = null;
    GraphNode<Country> currentSelectedCountry = null;

    #endregion

    #region Properties

    /// <summary>
    /// EndingText
    /// </summary>
    public static string EndingText
    {
        get { return endingText; }
    }

    /// <summary>
    /// Points 
    /// </summary>
    public static int Points
    {
        get { return points; }
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
    public long CurrentNumberOfInfectedGadgets
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
        get { return currentNumberofDeadPeople; }
    }

    /// <summary>
    /// Get a total number of current progress in antivirus research
    /// </summary>
    public float CurrentProgressInAntivirusResearch
    {
        get { return currentProgressInAntivirusResearch; }
    }

    /// <summary>
    /// Antivirus design
    /// </summary>
    public bool AntivirusDesigned
    {
        get { return antivirusDesigned; }
    }    
    
    /// <summary>
    /// Get a total number of Max progress in antivirus research
    /// </summary>
    public float MaxProgressInAntivirusResearch
    {
        get { return maxProgressInAntivirusResearch; }
    }

    /// <summary>
    /// Get a current Lethality
    /// </summary>
    public float CurrentLethality
    {
        get { return currentLethality; }
    }

    /// <summary>
    /// Get name of the world
    /// </summary>
    public string WorldName
    {
        get { return nameOfWorld; }
    }
    #endregion

    #region Methods    

    // Start is called before the first frame update
    void Start()
    {
        StartGame();

        //Get all links on countries
        countriesGameObj = GameObject.FindGameObjectsWithTag("Country");
        foreach (GameObject countryGameObj in countriesGameObj)
        {
            countriesScripts.Add(countryGameObj.GetComponent<Country>());
        }

        //Timer
        timerUpdateInformation = gameObject.AddComponent<Timer>();
        timerUpdateInformation.Duration = timerDurationUpdateInfromation;
        timerUpdateInformation.Run();

        //count the const parameters
        foreach (Country country in countriesScripts)
        {
            totalNumberOfGadgets = totalNumberOfGadgets + country.TotalNumberOfGadgets;
            totalNumberOfPeople = totalNumberOfPeople + country.TotalNumberOfPeople;
            researchPotential = researchPotential + country.ResearchPotential;
        }
        GetCurrentInformation();

        //references
        graph = GraphBuilder.Graph;
        //Timer
        timerCreatingNewPackeges = gameObject.AddComponent<Timer>();
        timerCreatingNewPackeges.Duration = timerDurationCreatingNewPackeges;
        timerCreatingNewPackeges.Run();

        //test
        //Matrix creation 
        //matrixCreation = true;
        //People pray on Ai
        //peoplePrayOnAI = true; 
        /*
        GameObject[] countries;
        countries = GameObject.FindGameObjectsWithTag("Country");
        if (countries.Length > 0)
        {
            foreach (GameObject country in countries)
            {
                country.GetComponent<Country>().GetInfectedPeople(11000);
            }
        }*/

        //test currentLethality
        //AddLethality(0.5f);

        //currentProgressInAntivirusResearch = maxProgressInAntivirusResearch;

        //points = 300;
    }

    // Update is called once per frame
    void Update()
    {
        // check for pausing game
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("PauseMenu") == null)
        {

            MenuManager.GoToMenu(MenuName.Pause);
            //AudioManager.Play(AudioClipName.PauseGame);

        }

        //Start the game
        if (!gameStarted && ControlInformalBar.SelectedCountry != null)
        {
            gameStarted = true;
            ControlInformalBar.SelectedCountry.GetInfectedGadget(1);

            //test
            //ControlInformalBar.SelectedCountry.GetInfectedPeople(1000000);
            //AddLethality(0.5f);
            // test Debug.Log("Did " + gameStarted);
        }

        if (timerUpdateInformation.Finished)
        {
            GetCurrentInformation();
            timerUpdateInformation.Run();

            //test
            //Debug.Log("currentNumberofDeadPeople = " + currentNumberofDeadPeople);
            //Debug.Log("totalNumberOfPeople = " + totalNumberOfPeople);

            //Antivirus
            if (currentProgressInAntivirusResearch == maxProgressInAntivirusResearch)
            {
                antivirusDesigned = true;
            }

            //Activate AI create button
            if ((float)currentNumberOfInfectedGadgets / (float)totalNumberOfGadgets > interesToActivateAIButton && !aIButtonCreated)
            {
                if (AIButton != null)
                {
                    AIButton.SetActive(true);
                    Debug.Log("CreateAI button was activated");
                }
                else
                {
                    Debug.Log("No references to AI Button  gameobject");
                }
                aIButtonCreated = true;
            }

            //end the game
            //Virus kill all people           
            if (!endGame)
            {
                if (currentNumberofDeadPeople >= totalNumberOfPeople)
                {
                    Debug.Log("All People Are Dead You Win ");
                    endingText = "All People Are Dead You Win ";
                    endGame = true;
                    // Create a game over menu
                    if (GameObject.FindGameObjectWithTag("GameOver") == null)
                    {
                        MenuManager.GoToMenu(MenuName.GameOver);
                    }
                    MouseCursor.CantControl();
                }
                else if (AntivirusDesigned)
                {
                    Debug.Log("you are lose, antivitus was design");
                    endingText = "you are lose, antivitus was design ";
                    endGame = true;
                    // Create a game over menu
                    if (GameObject.FindGameObjectWithTag("GameOver") == null)
                    {
                        MenuManager.GoToMenu(MenuName.GameOver);
                    }
                    MouseCursor.CantControl();
                }
                else if (currentNumberOfInfectedPeople >= totalNumberOfPeople - currentNumberofDeadPeople)
                {
                    if (matrixCreation)
                    {
                        Debug.Log("All people produce a electricity now, You Win");
                        endingText = "All people produce a electricity now, You Win";
                        endGame = true;
                        // Create a game over menu
                        if (GameObject.FindGameObjectWithTag("GameOver") == null)
                        {
                            MenuManager.GoToMenu(MenuName.GameOver);
                        }
                        MouseCursor.CantControl();
                    }
                    else if (peoplePrayOnAI)
                    {
                        Debug.Log("All people pray to AI You win");
                        endingText = "All people pray to AI You win ";
                        endGame = true;
                        // Create a game over menu
                        if (GameObject.FindGameObjectWithTag("GameOver") == null)
                        {
                            MenuManager.GoToMenu(MenuName.GameOver);
                        }
                        MouseCursor.CantControl();
                    }
                }
            }
        }

        //Creating a package when timer in finished in random country and sent it to the neighbor country
        if (timerCreatingNewPackeges.Finished)
        {

            currentSelectedCountry = graph.Nodes[Random.Range(0, graph.Nodes.Count)]; //select a random rountry 
            if (currentSelectedCountry != lastSelectedCountry && currentSelectedCountry.Neighbors.Count > 0) // check for two packages will not create in same country
            {
                GameObject package = Instantiate(packegePrefab, currentSelectedCountry.Value.Position, Quaternion.identity); //Create a package

                //count if the package will be infected
                bool willPackageBeInfected = false;
                int howManyComputersWillBeInfected = 0;
                Country selectedCountryScript = currentSelectedCountry.Value;
                float changeForPackageToBeInfected = Mathf.Clamp(selectedCountryScript.CurrentNumberOfInfectedGadgets / selectedCountryScript.TotalNumberOfGadgets, minChanseForPackageToBeInfected, 1); // count the chance to get package infercted
                if (changeForPackageToBeInfected > Random.value && selectedCountryScript.CurrentNumberOfInfectedGadgets > 0)
                {
                    willPackageBeInfected = true;
                    howManyComputersWillBeInfected = Random.Range(1, (int)(CurrentNumberOfInfectedGadgets / selectedCountryScript.TotalNumberOfGadgets * 1000)); //how many computers wil be infected
                }

                package.GetComponent<Package>().SetParameters(willPackageBeInfected, currentSelectedCountry.Neighbors[Random.Range(0, currentSelectedCountry.Neighbors.Count)].Value.gameObject, howManyComputersWillBeInfected); // Set a Package
                lastSelectedCountry = currentSelectedCountry; 
                timerCreatingNewPackeges.Run(); //reset timer
            }

        }
    }
    
    /// <summary>
    /// starts a game
    /// </summary>
    static public void StartGame()
    {
        currentProgressInAntivirusResearch = 0;
        currentLethality = 0;
        peoplePrayOnAI = false;
        matrixCreation = false;
        CoefficientData.ResetToZeroAdditionalPoints();
        endingText = " ";
        points = 0;
    }
    /// <summary>
    /// reduce Progress Of Antivirus Research on set number
    /// </summary>
    /// <param name="number">what number to reduce</param>
    public static void reduceProgressOfAntivirusResearch(float number)
    {
        currentProgressInAntivirusResearch = Mathf.Clamp(currentProgressInAntivirusResearch - number, 0, maxProgressInAntivirusResearch);
    }
    /// <summary>
    /// Add a points
    /// </summary>
    /// <param name="howMuchToAdd"></param>
    public static void AddPoints(int howMuchToAdd)
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
        //Debug.Log("points = " + points);
    }

    /// <summary>
    /// Count the parameters like current number of infected gadgets and people and dead people 
    /// </summary>
    void GetCurrentInformation()
    {
        //to nullify all parametars
        currentNumberOfInfectedGadgets = 0;
        currentNumberOfInfectedPeople = 0;
        currentNumberofDeadPeople = 0;

        // count the parametars 
        foreach (Country country in countriesScripts)
        {
            if (currentNumberOfInfectedGadgets <= totalNumberOfGadgets)
            {
                currentNumberOfInfectedGadgets = (long)Mathf.Clamp(currentNumberOfInfectedGadgets + country.CurrentNumberOfInfectedGadgets, 0, totalNumberOfGadgets);
            }

            if (currentNumberOfInfectedPeople < totalNumberOfPeople)
            {
                currentNumberOfInfectedPeople = (long)Mathf.Clamp(currentNumberOfInfectedPeople + country.CurrentNumberOfInfectedPeople, 0, totalNumberOfPeople);
            }

            if(currentNumberofDeadPeople < totalNumberOfPeople)
            currentNumberofDeadPeople = (long)Mathf.Clamp(currentNumberofDeadPeople + country.CurrentNumberOfDeadPeople, 0, totalNumberOfPeople);

            howMuchofThatPotentialIsUsed = howMuchofThatPotentialIsUsed + country.HowMuchofThatPotentialIsUsed;
        }
    }

    public void UpdateAntivirusResearch(float howMuchPeopleDesign)
    {
        currentProgressInAntivirusResearch = Mathf.Clamp(currentProgressInAntivirusResearch + howMuchPeopleDesign, 0, maxProgressInAntivirusResearch);
        //test
        //Debug.Log("currentProgressInAntivirusResearch = " + currentProgressInAntivirusResearch);
    }

    public static void AddLethality(float number)
    {
        currentLethality = Mathf.Clamp(currentLethality + number, 0 , 100000);
    }

    public static void ChangePeoplePrayOnAIFlag(bool flag)
    {
        peoplePrayOnAI = flag;

        //test
        //Debug.Log("peoplePrayOnAI " + peoplePrayOnAI);
    }

    public static void ChngeMatrixCreationFlag(bool flag)
    {
        matrixCreation = flag;

        //test
        //Debug.Log("matrixCreation " + matrixCreation);
    }

    #endregion
}
