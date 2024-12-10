using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    //This script is attached to the main camera and it is used to increase its position as the stack height increases
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if(Vars.stackHeight >= 2) //If the stack heigh is equal or greater of 2, camera position will start to increase
        {
            transform.position = Vector3.SmoothDamp (transform.position, new Vector3(0, Vars.stackHeight + 2, -10), ref velocity, 0.5f);
        }else {
            transform.position = Vector3.SmoothDamp (transform.position, new Vector3(0, 4, -10), ref velocity, 0.2f);
        }
    }
}
