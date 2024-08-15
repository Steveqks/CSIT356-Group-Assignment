using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridInfo : MonoBehaviour
{
    public string towertype;
    public TMP_Text title;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCanvasInfo()
    {
        title.text = towertype;
    }

    public void SetTowerType(string str)
    { 
        title.text = str; 
    }

}
