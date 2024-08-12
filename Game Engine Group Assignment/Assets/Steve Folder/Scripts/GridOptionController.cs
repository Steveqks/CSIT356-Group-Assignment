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

    //to open layer 1 options
    public void OnOpenLayer1Options()
    {
        selector.setGridActive(gameObject);
        // display the settings popup
        //option.gameObject.SetActive(true);

        Debug.Log("grid>options>open");
    }

    //to open layer 1 options
    public void OnOpenLayer2Options()
    {
        selector.setGridActive(gameObject);
        // display the settings popup
        //option.gameObject.SetActive(true);

        Debug.Log("grid>options>layer2");
    }

    public void OnCloseOptions()
    {
        // don't display the settings popup
        option.gameObject.SetActive(false);

        Debug.Log("grid>options>close");
    }

    public void onSell()
    {
        Debug.Log("grid > sell");
    }

    public void onBuildOptions()
    {
        Debug.Log(gameObject.transform.Find("Build_options"));
        Debug.Log(gameObject.transform.Find("Build"));
        selector.setGridActive(transform.Find("Build_options").gameObject);
        //selector.setGridActive(gameObject);
        Debug.Log("grid > build");
    }

    public void onBuild1()
    {
        Debug.Log("grid > build1");
    }

    public void onBuild2()
    {
        Debug.Log("grid > build2");
    }

    public void onBuild3()
    {
        Debug.Log("grid > build3");
    }

}
