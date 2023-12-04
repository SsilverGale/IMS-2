using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : ObjectMovement
{

    //Our moving thing
    [SerializeField] private GameObject platform;

    //Where are we going?
    private Vector2 move;

    //This is needed for boundary checks
    private bool isEndAboveStart;

    // Start is called before the first frame update
    void Start()
    {
        //What direction an I moving?
        move = new Vector2(GetEndLocation().position.x - GetStartLocation().position.x, GetEndLocation().position.y - GetStartLocation().position.y);

        //Set the object at the start point
        //This was removed because what if you want an object out of faze of other objects
        //platform.GetComponent<Transform>().position = GetStartLocation().position;
        platform.GetComponent<Transform>().position += (Vector3)move * Mathf.Sin(faze);
        

        //How fast does it move?
        moveSpeed = 0.5f;

        //Check if the object is moving up to start or down to start
        //This is needed for the back-and-forth motion
        isEndAboveStart = (GetEndLocation().position.y > GetStartLocation().position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Move in the right direction
        if (isGoingRight)
        {
            //Debug.Log("isGoingRight");
            platform.transform.Translate(move * moveSpeed * Time.deltaTime);
        }
        else if (!isGoingRight)
        {
            //Debug.Log("isNotGoingRight");
            platform.transform.Translate(-move * moveSpeed * Time.deltaTime);
        }


        //Checks for if we need to turn around
        //if the object starts by moving up
        if (GetStartLocation().position.y > platform.transform.position.y && isEndAboveStart)
        {
            isGoingRight = true;
        }
        
        if (GetEndLocation().position.y < platform.transform.position.y && isEndAboveStart)
        {
            isGoingRight = false;
        }
        
        //if the object starts by moving down
        if (GetStartLocation().position.y < platform.transform.position.y && !isEndAboveStart)
        {
            isGoingRight = true;
        }
        
        if (GetEndLocation().position.y > platform.transform.position.y && !isEndAboveStart)
        {
            isGoingRight = false;
        }
    }
}
