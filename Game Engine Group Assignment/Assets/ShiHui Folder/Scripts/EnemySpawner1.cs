using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemySpawner1 : MonoBehaviour
{
    public GameObject[] groundEnemyPrefabs;
    public GameObject[] airEnemyPrefabs;
    public Transform[] groundWaypoints; // Array to hold waypoint transforms
    public Transform[] airWaypoints; // Array to hold waypoint transforms
    GameObject enemy;

    public int numEnemy = 10;

    private Vector3 groundPos;
    private Vector3 airPos;

    void Start()
    {
        groundPos = transform.position;
        airPos = transform.position + new Vector3(0f, 3.5f, 0f);
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        int ranNum;

        for (int i = 0; i < numEnemy; i++)
        {
            int ranPos = Random.Range(0, 2); // 0 is ground, 1 is air 
            if (ranPos == 0)
            {
                ranNum = Random.Range(0, 2); // 0 is fast, 1 is slow
                if (ranNum == 0)
                {
                    enemy = Instantiate(groundEnemyPrefabs[ranNum], groundPos, Quaternion.identity);
                }
                else
                {
                    enemy = Instantiate(groundEnemyPrefabs[ranNum], groundPos, Quaternion.identity);
                }
            }
            else
            {
                ranNum = Random.Range(0, 2); // 0 is fast, 1 is slow
                if (ranNum == 0)
                {
                    enemy = Instantiate(airEnemyPrefabs[ranNum], airPos, Quaternion.identity);
                }
                else
                {
                    enemy = Instantiate(airEnemyPrefabs[ranNum], airPos, Quaternion.identity);
                }
            }

            if (enemy != null)
            {
                EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
                if (enemyMovement != null)
                {
                    if (ranPos == 0)
                    {
                        Debug.Log("Call SetWaypoints - " + enemy.gameObject.name);
                        enemyMovement.SetWaypoints(groundWaypoints);
                    }
                    else
                    {
                        Debug.Log("Call SetWaypoints - " + enemy.gameObject.name);
                        enemyMovement.SetWaypoints(airWaypoints);
                    }
                    
                }
            }

            // spawn next enemy after 1sec
            yield return new WaitForSeconds(0.5f);
            
        }
    }
}
