using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOptionController : MonoBehaviour
{
    private GameObject option;
    public GridSelectorController selector;

    // Start is called before the first frame update
    void Start()
    {
        option = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    public void onSell()
    {
        Debug.Log("on sell");
    }

    public void onBuild1()
    {
        Debug.Log("on build1");
    }

    public void onBuild2()
    {
        Debug.Log("on build2");
    }

    public void onBuild3()
    {
        Debug.Log("on build3");
    }

}
