using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClickHandler : MonoBehaviour
{
    // for opening layer1 layer2 options
    public TileSelectorController selector;

    // options background
    public GameObject options;

    // selecting layer 1 options
    public GameObject optionL1;

    // selecting layer 2 options
    public GameObject optionL2;

    // used to store which tile selected for reference
    private TileInfo tileInfo;

    // for Tile Options Menu, for storing temporary information.
    public TileOption tileOption;

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
        Debug.Log("plot clicked!");

        // You can add any action you want here, e.g., changing color, starting an animation, etc.
        // Example: Change the color of the cube

        optionL1.SetActive(true);
        optionL2.SetActive(false);
        options.SetActive(true);
        
        tileInfo = GetComponent<TileInfo>();

        Debug.Log(tileInfo);   

        tileOption.loadStatus(tileInfo.getTileInfo());
    }
}
