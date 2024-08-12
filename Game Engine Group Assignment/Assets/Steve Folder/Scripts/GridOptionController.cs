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

    public void OnOpenSettings()
    {
        selector.setGridActive(gameObject);
        // display the settings popup
        //option.gameObject.SetActive(true);

        Debug.Log("grid>options>open");
    }

    public void OnCloseSettings()
    {
        // don't display the settings popup
        option.gameObject.SetActive(false);

        Debug.Log("grid>options>close");
    }

    public void onSell()
    {
        Debug.Log("grid > sell");
    }

    public void onBuild()
    {
        Debug.Log("grid > build");
    }


}
