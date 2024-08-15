using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class TileInfoOptionController : MonoBehaviour
{
    public TileSelectorController selector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    public void onSell()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();

        ti.setTileinfo("empty");

        Debug.Log(ti);
        //gi.SetTowerType("ARROWS");
        Debug.Log("on sell");
    }

    public void onBuild1()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();

        ti.setTileinfo("Arrows");

        Debug.Log(ti);
        //gi.SetTowerType("ARROWS");
        Debug.Log("on build1");

    }

    public void onBuild2()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();

        ti.setTileinfo("Cannons");

        Debug.Log(ti);
        //gi.SetTowerType("ARROWS");
        Debug.Log("on build2");

    }

    public void onBuild3()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();

        ti.setTileinfo("Sniper");

        Debug.Log(ti);
        //gi.SetTowerType("ARROWS");
        Debug.Log("on build3");
    }

}
