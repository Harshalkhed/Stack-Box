using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewSquare : MonoBehaviour
{
    //This script is used to create a new square at the start of the game or when previous square is dropped
    public int numberOfSquares = 0;
    void OnEnable()
    {
        numberOfSquares = 0;
        NewSquare();
    }

    public void NewSquare() {
        numberOfSquares++;
        GameObject square = Instantiate(Resources.Load("Square", typeof(GameObject))) as GameObject;
        square.gameObject.name = "Square" + numberOfSquares;
        var cubeRenderer = square.GetComponent<Renderer>();
       
        int randomColor = Random.Range(0, 5);
        if(randomColor == 0) 
        {
            cubeRenderer.material.SetColor("_Color", new Color(0.7176471f, 0.882353f, 0.9529412f));
        }else if(randomColor == 1) 
        {
            cubeRenderer.material.SetColor("_Color", new Color(0.09411766f, 0.6039216f, 0.6588235f));
        }else if(randomColor == 2) 
        {
            cubeRenderer.material.SetColor("_Color", new Color(0.6666667f, 0.8274511f, 0.3372549f));
        }else if(randomColor == 3) 
        {
            cubeRenderer.material.SetColor("_Color", new Color(0.9764706f, 0.7882354f, 0.03137255f));
        }else if(randomColor == 4) 
        {
            cubeRenderer.material.SetColor("_Color", new Color(0.9529412f, 0.345098f, 0.2666667f));
        }
        
        if(Random.Range(0, 2) == 0) 
        {
            square.transform.position = new Vector2(-2, Vars.stackHeight + 5);
        }else{
            square.transform.position = new Vector2(2, Vars.stackHeight + 5);
        }
    }
}
