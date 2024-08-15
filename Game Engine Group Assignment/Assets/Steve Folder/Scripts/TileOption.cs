using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileOption : MonoBehaviour
{
    public string towertype;
    public TMP_Text tiletitle;
    public TileInfo tileInfo;

    // store current position of selected tower
    Transform tilePosition;
    
    


    // Start is called before the first frame update
    void Start()
    {
        tiletitle.text = this.towertype;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadStatus(TileInfo ti)
    {
        this.towertype = ti.getGridTowerType();
        tiletitle.text = this.towertype;

        tileInfo = ti;

        tilePosition = ti.transform;
    }

    public void setTileinfo(string str)
    {
        tileInfo.setTileInfo(str);
        tiletitle.text = str;
    }

    public Vector3 GetTransform()
    {
        return tilePosition.position;
    }

    public void setTowerModel(GameObject obj)
    {
        tileInfo.setTowerModel(obj);
    }

    public void destroyTowerModel()
    {
        tileInfo.destroyTowerModel();
    }
}
