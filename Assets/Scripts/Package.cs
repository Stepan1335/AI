using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Control a information packages between countries
/// </summary>
public class Package : MonoBehaviour
{
    public float speed = 0.1f;
    bool infectedPackege = false;
    GameObject countryToFollow;

    bool infectedDone = false;
    int numberOfInfectedComputers = 1;
    Vector2 currentPosition;
    Vector2 targetPosition;

    //References
    Animator animator;

    private void Start()
    {
        //set links
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move a package from one country to another 
        if (countryToFollow != null)
        {
            currentPosition = transform.position;
            targetPosition = countryToFollow.transform.position;
            if ( Vector2.Distance(currentPosition, targetPosition) < 0.1)
            {

                transform.position = targetPosition;
            }
            else
            {
                transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
            }

            //when packege came to needed country play end animation and destroy gameobject
            if (currentPosition == targetPosition)
            {
                //if packege infected so infect the country where it was arrived
                if (infectedPackege && !infectedDone)
                {
                    countryToFollow.GetComponent<Country>().GetInfectedGadget(numberOfInfectedComputers); //infect the country
                    infectedDone = true;    //like end animation has a time to play I need to execute this code only one time
                }
                animator.SetBool("MovedToPoint", true); //play the end animation
                Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);//destroy a gameobject after animation was played
            }

            //test
            //Debug.Log("position = " + transform.position + " need position = " + countryToFollow.transform.position);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="infectedPackege">if packege is infected</param>
    /// <param name="country">Country where follow the packege</param>
    /// <param name="numberOfInfectedFiles">number of computers what will be infected in that country</param>
    public void SetParameters(bool infectedPackege, GameObject country, int numberOfInfectedFiles)
    {
        this.infectedPackege = infectedPackege;
        this.numberOfInfectedComputers = numberOfInfectedFiles;
        countryToFollow = country;
        targetPosition = countryToFollow.GetComponent<Country>().Position;

        if (infectedPackege)
        {
            GetPackageInfected();
        }
    }

    /// <summary>
    /// if packege is infected change color to red 
    /// </summary>
    void GetPackageInfected()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
    }
}
