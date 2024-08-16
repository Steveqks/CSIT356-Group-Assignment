using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] waypoints; // Array to hold waypoint transforms
    GameObject enemy;

    void Start()
    {
        // Instantiate the enemy prefab
       enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (enemy != null)
        {
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                Debug.Log("Call SetWaypoints");
                enemyMovement.SetWaypoints(waypoints);
            }
        }
    }
}
