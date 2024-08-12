using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSelectorController : MonoBehaviour
{
    GameObject GridCurrent;
    Transform GridActivate;
    GameObject GridDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSelector()
    {

        gameObject.SetActive(false);

        //Debug.Log("GridActivate grid: " + GridActivate);

        if (GridCurrent == null)
        {
            //GridActivate.gameObject.SetActive(true);
            //GridCurrent = GridActivate.gameObject;
            

        }
        else
        {
            //GridCurrent.SetActive(false);
            //GridActivate.gameObject.SetActive(true);
        }

    }

    public void setGridActive(GameObject obj)
    {
        if (GridDeactivate != null)
        {
            GridDeactivate.SetActive(false);
        }

        Debug.Log("this game obj: " + obj);

        obj.SetActive(true);

        GridDeactivate = obj;
        /*
        obj.transform.gameObject.SetActive(true);
        Debug.Log("msg gameObject is: " + obj);
        Debug.Log("is true");
            //.gameObject.SetActive(true);
        */
    }
}
