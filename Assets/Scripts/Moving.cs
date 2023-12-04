using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    private Vector2 currentPoint;

    private Vector2 pos;
    private Vector2 point1Pos;
    private Vector2 point2Pos;

    // Start is called before the first frame update
    void Start()
    {
        point1Pos = point1.transform.position;
        point2Pos = point2.transform.position;
        transform.position = point1Pos;
        currentPoint = point2Pos;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        pos = transform.position;

        transform.position = Vector2.MoveTowards(transform.position, currentPoint, step);

        if(pos == currentPoint && currentPoint == point2Pos)
        {
            currentPoint = point1Pos;
        }
        else if (pos == currentPoint && currentPoint == point1Pos)
        {
            currentPoint = point2Pos;
        }
    }
}
