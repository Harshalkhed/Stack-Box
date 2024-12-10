using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTheSquare : MonoBehaviour
{
    //This script is attached to each square game object and it is used to drop the square when player clicks the mouse or touches the screen
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Input.mousePosition.y > (Screen.height - Screen.height / 7)) return;//This will prevent dropping the square if the users clicks on the upper side of the screen where the pause button is located
            if(Time.timeScale == 0) return;
            Destroy(GetComponent<SquareMovement> ());
            GetComponent<Rigidbody>().isKinematic = false;
            if (GetComponent<SquarePositioned> () != null)
            {
                GetComponent<SquarePositioned> ().enabled = true;
            }
            GameObject.Find("SquareDropSound").GetComponent<AudioSource> ().Play();
            PlayerPrefs.SetInt("DroppedBoxes", PlayerPrefs.GetInt("DroppedBoxes") + 1);
            Destroy(GetComponent<DropTheSquare> ());
        }
    }
    
}
