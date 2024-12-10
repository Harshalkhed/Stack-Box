using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //This script is attached to the "BottomPlatform" and "BottomColider" game objects and it is used to show game over menu when square falls of the stack
   /* void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name != "Square1")//If any square other then the first one hits the "BottomPlatform" the game is over
        {
            GameObject.Find("GameManager").GetComponent<UserInterface> ().GameOver();
        }
    }*/
    void OnTriggerEnter(Collider col)//If any square hits the "BottomColider" the game is over
    {
        GameObject.Find("GameManager").GetComponent<UserInterface> ().GameOver();
    }
}
