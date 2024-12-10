using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareAppearingAnimation : MonoBehaviour
{
    //This script is used to create a simple zoom in animation when square appears on the screen
    private float scaleX = 0;
    private float scaleYZ = 0;

    void Start() {
        scaleX = Random.Range(0.5f, 1f);
    }

    void Update()
    {
        scaleYZ += Time.deltaTime * 3;
        if(scaleYZ >= 1) {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<SquareMovement> ().enabled = true;
            GetComponent<DropTheSquare> ().enabled = true;
            Destroy(GetComponent<SquareAppearingAnimation> ());
        }
        transform.localScale = new Vector3(scaleX, scaleYZ, scaleYZ);
    }
}
