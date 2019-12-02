using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEffect : MonoBehaviour
{
    //references
    SpriteRenderer image;
    Country country;
    Timer timer;

    //priority coefficients
    float gadgetPriorityCoefficient = 0;
    float infectedPeoplePriorityCoefficient = 0;
    float deadPeoplePriorityCoefficient = 0;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        country = GetComponentInParent<Country>();

        //timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            
            gadgetPriorityCoefficient = (float)country.CurrentNumberOfInfectedGadgets / (float)country.TotalNumberOfGadgets;
            infectedPeoplePriorityCoefficient = (float)country.CurrentNumberOfInfectedPeople / ((float)country.TotalNumberOfPeople - (float)country.CurrentNumberOfDeadPeople) * 1.5f;
            deadPeoplePriorityCoefficient = (float)country.CurrentNumberOfDeadPeople / (float)country.TotalNumberOfPeople * 2;
           
            //count the maximum coefficient
            float priorityCoefficient = Mathf.Max(gadgetPriorityCoefficient, infectedPeoplePriorityCoefficient, deadPeoplePriorityCoefficient);

            if (gadgetPriorityCoefficient >= priorityCoefficient)
            {
                image.color = new Color(0, 0.7f, 0.7f, Mathf.Clamp((float)country.CurrentNumberOfInfectedGadgets / (float)country.TotalNumberOfGadgets, 0, 0.4f));
            }

            else if (infectedPeoplePriorityCoefficient >= priorityCoefficient)
            {
                image.color = new Color(0.82f, 0.06f, 0, Mathf.Clamp((float)country.CurrentNumberOfInfectedPeople / (float)country.TotalNumberOfPeople, 0, 0.4f));                
            }
            else if (deadPeoplePriorityCoefficient >= priorityCoefficient)
            {
                image.color = new Color(0, 0, 0, Mathf.Clamp((float)country.CurrentNumberOfDeadPeople / (float)country.TotalNumberOfPeople, 0, 0.4f));
            }
            timer.Run();
        }
    }
}
