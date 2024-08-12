using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOptionController : MonoBehaviour
{
    [SerializeField] GameObject option;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOpenSettings()
    {
        // display the settings popup
        option.gameObject.SetActive(true);

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
