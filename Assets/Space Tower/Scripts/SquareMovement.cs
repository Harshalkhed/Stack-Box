using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    //This script is attached to each square and it is used to move the square left and right on the screen
    private bool right = true;
    private float speed = 5;
    void Start() 
    {
        speed = Random.Range(3, 5);
    }
    void Update()
    {
        if(right) 
        {
            transform.localPosition = new Vector2(transform.localPosition.x + speed * Time.deltaTime, Vars.stackHeight + 5);
            if(transform.localPosition.x >= 2) 
            {
                right = false;
            }
        }else
        {
            transform.localPosition = new Vector2(transform.localPosition.x - speed * Time.deltaTime, Vars.stackHeight + 5);
            if(transform.localPosition.x <= -2) 
            {
                right = true;
            }
        }
    }
}
