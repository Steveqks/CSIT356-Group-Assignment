using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public string towertype;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void setTileInfo(string str)
    {
        towertype = str;
    }

    public string getGridTowerType()
    {
        return towertype;
    }

    public TileInfo getTileInfo()
    {
        return this;
    }

}
