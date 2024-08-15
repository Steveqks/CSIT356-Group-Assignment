using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.PackageManager;
using UnityEngine;

public class TileInfoOptionController : MonoBehaviour
{
    public TileSelectorController selector;

    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;

    public GameObject instantiatedTower;

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
        Debug.Log("on sell");

        ti.destroyTowerModel();
        
    }

    public void onBuild1()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();

        ti.setTileinfo("Arrows");

        Debug.Log("on build1");

        instantiatedTower = Instantiate(tower1, ti.GetTransform(), Quaternion.identity); 
        ti.setTowerModel(instantiatedTower);
    }

    public void onBuild2()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();

        ti.setTileinfo("Cannons");

        Debug.Log("on build2");

        instantiatedTower = Instantiate(tower2, ti.GetTransform(), Quaternion.identity);
        ti.setTowerModel(instantiatedTower);

    }

    public void onBuild3()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();

        ti.setTileinfo("Sniper");

        Debug.Log("on build3");

        instantiatedTower = Instantiate(tower3, ti.GetTransform(), Quaternion.identity);
        ti.setTowerModel(instantiatedTower);
    }

}
