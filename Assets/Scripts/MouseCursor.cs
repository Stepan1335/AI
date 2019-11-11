using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// make a object follow the mouse 
/// </summary>
public class MouseCursor : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        // convert mouse position to world position 
        Vector3 position = Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);
        //make the object follow the mouse cursor
        transform.position = position;
    }

    
    private void OnTriggerStay2D(Collider2D coll)
    {
        //Select the country and deselect all others
        Country scriptCountry = coll.gameObject.GetComponent<Country>();

        //if mouse get down show the animation 
        if (Input.GetMouseButtonDown(0))
        {
            //Deselect a country
            GameObject [] countries =  GameObject.FindGameObjectsWithTag("Country");
            foreach (GameObject country in countries)
            {
                country.GetComponent<Country>().GetDeselected();
            }
            //test
            Debug.Log("The number of countries = " + countries.Length); 

            //Select the country
            scriptCountry.GetSelected();
            //Debug.Log("true");
        }
    }
}
