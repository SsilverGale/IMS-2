using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectMovement : MonoBehaviour
{

    //Where are the objects moving
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;

    //Which direction is the object moving
    [SerializeField] protected bool isGoingRight = true;

    //How fast does the object move?
    protected float moveSpeed;

    //The positions of the stat and end
    protected Transform startLocation;
    protected Transform endLocation;

    //Faze
    [SerializeField, Range(0f, 1.57f)] protected float faze;


    private void Start()
    {
        //Inicialize the locations
        GetStartLocation();
        GetEndLocation();
    }

    protected Transform GetStartLocation()
    {
        //Getting the Start location
        startLocation = startPoint.GetComponent<Transform>();

        return startLocation;
    }

    protected Transform GetEndLocation()
    {
        //Getting the End location
        endLocation = endPoint.GetComponent<Transform>();

        return endLocation;
    }

}
