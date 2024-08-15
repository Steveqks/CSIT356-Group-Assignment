using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileOption : MonoBehaviour
{
    public string towertype;
    public TMP_Text tiletitle;
    public TileInfo tileInfo;

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
    }

    public void setTileinfo(string str)
    {
        tileInfo.setTileInfo(str);
        tiletitle.text = str;
    }
    

}
