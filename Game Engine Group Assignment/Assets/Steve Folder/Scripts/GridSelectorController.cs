using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSelectorController : MonoBehaviour
{
    GameObject GridCurrent;
    Transform GridActivate;
    GameObject GridDeactivate;


    [SerializeField] GameObject OptionL1;
    [SerializeField] GameObject OptionL2;
    [SerializeField] GameObject Canvas1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGridActive(GameObject obj)
    {
        //check if any active previously
        if (GridDeactivate != null)
        {
            //deactivate previously opened option
            GridDeactivate.SetActive(false);
        }

        //display new selected option 
        obj.SetActive(true);

        GridDeactivate = obj;
    }

    public void setLayer1()
    {
        OptionL1.SetActive(true);
    }

    public void setLayer2()
    {
        OptionL1.SetActive(false);
        OptionL2.SetActive(true);
    }

    public void closeOption()
    {
        OptionL2.SetActive(false);
        OptionL1.SetActive(true);
        Canvas1.SetActive(false);
    }
}
