using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public string towertype;

    // store instance of instantiated tower
    GameObject instantiatedTower;

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

    public void setTowerModel(GameObject obj)
    {
        instantiatedTower = obj;
    }

    public void destroyTowerModel()
    {
        Destroy(instantiatedTower);
    }
}
