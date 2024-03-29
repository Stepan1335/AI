﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// make a object follow the mouse 
/// </summary>
public class MouseCursor : MonoBehaviour
{
    static bool canControl = true;//need for turning of a contron when user in virus control panel

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
        if (canControl)
        {
            if (coll.CompareTag("Country"))
            {
                //Select the country and deselect all others
                Country scriptCountry = coll.gameObject.GetComponent<Country>();

                //if mouse get down show the animation 
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject[] countries = GameObject.FindGameObjectsWithTag("Country");
                    //test
                    //Debug.Log("The number of countries = " + countries.Length);
                    foreach (GameObject country in countries)
                    {
                        country.GetComponent<Country>().GetDeselected();
                    }
                    //Select the country
                    scriptCountry.GetSelected();
                    //Debug.Log("true");
                }
            }
            if (coll.CompareTag("World"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject[] countries = GameObject.FindGameObjectsWithTag("Country");
                    //test
                    //Debug.Log("The number of countries = " + countries.Length);
                    foreach (GameObject country in countries)
                    {
                        country.GetComponent<Country>().GetDeselected();
                    }
                }
            }
        }
    }

    /// <summary>
    /// turn on control in game
    /// </summary>
    static public void CanControl()
    {
        canControl = true;
    }

    static public void CantControl()
    {
        canControl = false;
    }
}
