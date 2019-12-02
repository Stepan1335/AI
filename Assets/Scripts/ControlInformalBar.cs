using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// show the information about selected country or about the World in InformanBar
/// </summary>
public class ControlInformalBar : MonoBehaviour
{
    //references
    public Text currentNumberOfInfectedGadgets;
    public Text currentNumberOfInfectedPeople;
    public Text currentNumberOfDeadPeople;
    public Text interesOfAntivirusResearch;
    public Text countryName;
    public Text pointsText;
    public Image gadgetInfectedBar;
    public Image peopleInfectedBar;
    public Image peopleDeadBar;
    public Image antivirusBar;
    public Image pointsBar;

    static Country selectedCountry;
    World worldScript;

    /// <summary>
    /// Get a Selected Country
    /// </summary>
    public static Country SelectedCountry
    {
        get { return selectedCountry; }
    }

    // Start is called before the first frame update
    void Start()
    {
        worldScript = GameObject.FindGameObjectWithTag("World").GetComponent<World>();
    }

    // Update is called once per frame
    void Update()
    {
        //update the data in informalBar
        if (selectedCountry != null)
        {
            //change the text current number of infected gadgets
            currentNumberOfInfectedGadgets.text = selectedCountry.CurrentNumberOfInfectedGadgets.ToString();

            //change the fillamount of infected gadgets
            gadgetInfectedBar.fillAmount = (float)selectedCountry.CurrentNumberOfInfectedGadgets / (float)selectedCountry.TotalNumberOfGadgets;

            //change the text current number of infected people
            currentNumberOfInfectedPeople.text = selectedCountry.CurrentNumberOfInfectedPeople.ToString();

            //change the fillamount of infected people
            peopleInfectedBar.fillAmount = (float)selectedCountry.CurrentNumberOfInfectedPeople / ((float)selectedCountry.TotalNumberOfPeople - (float)selectedCountry.CurrentNumberOfDeadPeople);

            //change the text current number of dead people
            currentNumberOfDeadPeople.text = selectedCountry.CurrentNumberOfDeadPeople.ToString();

            //change the fillamount of dead people
            peopleDeadBar.fillAmount = (float)selectedCountry.CurrentNumberOfDeadPeople / (float)selectedCountry.TotalNumberOfPeople;

            //change the antivirus interests text
            //interesOfAntivirusResearch.text = Mathf.Round(selectedCountry.CurrentProgressInAntivirusResearch).ToString();

            //change the antivirus interests bar
            //antivirusBar.fillAmount = selectedCountry.CurrentProgressInAntivirusResearch / 100;


        }

        else
        {
            //Set the World name 
            countryName.text = worldScript.WorldName;

            //change the text current number of infected gadgets
            currentNumberOfInfectedGadgets.text = worldScript.CurrentNumberOfInfectedGadgets.ToString();

            //change the fillamount of infected gadgets
            gadgetInfectedBar.fillAmount = (float)worldScript.CurrentNumberOfInfectedGadgets / (float)worldScript.TotalNumberOfGadgets;

            //change the text current number of infected people
            currentNumberOfInfectedPeople.text = worldScript.CurrentNumberOfInfectedPeople.ToString();

            //change the fillamount of infected people
            peopleInfectedBar.fillAmount = (float)worldScript.CurrentNumberOfInfectedPeople / ((float)worldScript.TotalNumberOfPeople - (float)worldScript.CurrentNumberOfDeadPeople);

            //change the text current number of dead people
            currentNumberOfDeadPeople.text = worldScript.CurrentNumberOfDeadPeople.ToString();

            //change the fillamount of dead people
            peopleDeadBar.fillAmount = (float)worldScript.CurrentNumberOfDeadPeople / (float)worldScript.TotalNumberOfPeople;


        }

        //change the antivirus interests text
        interesOfAntivirusResearch.text = Mathf.Round(worldScript.CurrentProgressInAntivirusResearch).ToString();

        //change the antivirus interests bar
        antivirusBar.fillAmount = worldScript.CurrentProgressInAntivirusResearch / worldScript.MaxProgressInAntivirusResearch;

        //change the Points text
        pointsText.text = World.Points.ToString();

        //change the PointsBar
        pointsBar.fillAmount = (float)World.Points / 100;

    }

    /// <summary>
    /// Select the country 
    /// </summary>
    public void GetSellected( Country country)
    {
        selectedCountry = country;

        //Set the country name 
        countryName.text = selectedCountry.CountryName;
    }

    /// <summary>
    /// Deselect the country
    /// </summary>
    public void GetDesellected()
    {
        selectedCountry = null;
    }
}
