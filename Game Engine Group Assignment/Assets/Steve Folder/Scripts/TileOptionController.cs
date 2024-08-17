using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        TileOption to = tileInfo.GetComponent<TileOption>();


        // retreive tile tower info
        if(to.getTileTowerType() == "Arrows")
        {
            GameObject playerStatus = GameObject.FindGameObjectWithTag("PlayerStatus");
            PlayerStatus ps = playerStatus.GetComponent<PlayerStatus>();
            ps.itemSold(5);
        }

        else if (to.getTileTowerType() == "Cannons")
        {
            GameObject playerStatus = GameObject.FindGameObjectWithTag("PlayerStatus");
            PlayerStatus ps = playerStatus.GetComponent<PlayerStatus>();
            ps.itemSold(7);
        }

        else if (to.getTileTowerType() == "Sniper")
        {
            GameObject playerStatus = GameObject.FindGameObjectWithTag("PlayerStatus");
            PlayerStatus ps = playerStatus.GetComponent<PlayerStatus>();
            ps.itemSold(10);
        }
        
        Debug.Log("123tower type is: " + to.getTileTowerType());
        Debug.Log("on sell");

        to.setTileinfo("empty");

        to.destroyTowerModel();

        
    }

    public void onBuild1()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();

        if (!ti.isTowerInstantiate())
        {
            ti.setTileinfo("Arrows");

            Debug.Log("on build1");

            instantiatedTower = Instantiate(tower1, ti.GetTransform(), Quaternion.identity);
            ti.instantiateTowerModel(instantiatedTower);
        }
        else Debug.Log("Tile already occupied by a tower, sell a tower first");

    }

    public void onBuild2()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();



        if (!ti.isTowerInstantiate())
        {
            ti.setTileinfo("Cannons");

            Debug.Log("on build2");

            instantiatedTower = Instantiate(tower2, ti.GetTransform(), Quaternion.identity);
            ti.instantiateTowerModel(instantiatedTower);
        }
        else Debug.Log("Tile already occupied by a tower, sell a tower first");
    }

    public void onBuild3()
    {
        Transform tileInfo = transform.parent.parent;

        TileOption ti = tileInfo.GetComponent<TileOption>();



        if (!ti.isTowerInstantiate())
        {
            ti.setTileinfo("Sniper");

            Debug.Log("on build3");

            instantiatedTower = Instantiate(tower3, ti.GetTransform(), Quaternion.identity);
            ti.instantiateTowerModel(instantiatedTower);
        }
        else Debug.Log("Tile already occupied by a tower, sell a tower first");
    }

}
