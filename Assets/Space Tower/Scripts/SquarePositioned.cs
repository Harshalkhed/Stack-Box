using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePositioned : MonoBehaviour
{
    //This script is attached to each square game object and it is used to checked if the square is correctly position at the top of the other square
    private bool hasHitTheBottom = false;
    private bool isSoundPlayed = false;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody> ();
    }
    void Update()
    {
        if(!hasHitTheBottom) return;

        if(Mathf.Abs(rb.velocity.x) < 0.05f && Mathf.Abs(rb.velocity.y) < 0.05f) //Checks if the square is correctly position at the top of the other square
        {
            if(transform.position.y > Vars.stackHeight)
                Vars.stackHeight = transform.position.y;
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<CreateNewSquare> ().NewSquare();//New square will be created on the scene
            gameManager.GetComponent<UserInterface> ().StackMeasurement();//It will show the height of the stack on the UI
            Destroy(GetComponent<SquarePositioned> ());
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Invoke("HitTheBottom", 0.5f);
        if(!isSoundPlayed)
        {
            isSoundPlayed = true;
            GameObject.Find("HitSound").GetComponent<AudioSource> ().Play();
        }
    }

    private void HitTheBottom() {
        hasHitTheBottom = true;
    }
}
