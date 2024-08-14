using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClickHandler : MonoBehaviour
{

    public GridSelectorController selector;

    public GameObject grid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method will be called when the mouse clicks the cube
    void OnMouseDown()
    {
        // Example action: log to the console
        Debug.Log("Cube clicked!");

        // You can add any action you want here, e.g., changing color, starting an animation, etc.
        // Example: Change the color of the cube
        GetComponent<Renderer>().material.color = Color.red;
        
        grid.SetActive(true); 
    }
}
