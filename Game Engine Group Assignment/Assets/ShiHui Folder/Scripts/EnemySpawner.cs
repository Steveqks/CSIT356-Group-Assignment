using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    //public GameObject enemyPrefab;
    public GameObject[] enemyPrefabs;
    public Transform[] waypoints; // Array to hold waypoint transforms
    GameObject enemy;

    public int numEnemy = 2;

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        for (int i = 0; i < numEnemy; i++)
        {
            int ranNum = Random.Range(0, 2); // 0 is fast, 1 is slow
            Debug.Log("randome number = " + ranNum);
            enemy = Instantiate(enemyPrefabs[ranNum], transform.position, Quaternion.identity);

            if (enemy != null)
            {
                EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
                if (enemyMovement != null)
                {
                    Debug.Log("Call SetWaypoints");
                    enemyMovement.SetWaypoints(waypoints);
                }
            }
            // spawn next enemy after 1sec
            yield return new WaitForSeconds(1);
        }
    }
}
