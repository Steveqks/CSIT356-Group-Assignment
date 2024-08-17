using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject towerPrefab;
    public Button buildButton;
    public Transform interactiveGrid;
    public Button sellButton;

    private GameObject currentTower;


    private void Start()
    {
        buildButton.onClick.AddListener(() => OnBuildArrowTowerButtonClicked());
        sellButton.onClick.AddListener(() => OnSellCurrentTowerButtonClicked());
    }

    private void OnBuildArrowTowerButtonClicked()
    {
        if (currentTower != null)
        {
            Debug.LogWarning("This grid is OCCUPIED!");
        }
        else
        {
            Debug.Log("Arrow Tower is BUILT!");
            currentTower = Instantiate(towerPrefab, interactiveGrid.position, Quaternion.identity);
        }
    }

    private void OnSellCurrentTowerButtonClicked()
    {
        if (currentTower != null)
        {
            Debug.Log("Tower SOLD!");
            Destroy(currentTower);
        }
        else
        {
            Debug.LogWarning("NO TOWER FOUND");
        }
    }

    private void BuildTower(int x, int y)
    {

    }
    public void SetGridSize(int newGridSizeX, int newGridSizeY)
    {

    }
}
