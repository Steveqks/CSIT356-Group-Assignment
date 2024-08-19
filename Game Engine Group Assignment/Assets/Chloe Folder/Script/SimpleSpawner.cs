using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// simple spawner for 1 type enemy
// for testing purposes
public class SimpleSpawner : MonoBehaviour
{
	public GameObject enemy_Prefab;
	public List<Transform> waypoints;
	public int maxEnemyOnField = 10;
	private int enemyOnField;

	// timer for spawner
	public float startTimer = 1.0f;
	public float spawnTimer = 0.5f;

	void Start()
	{
		enemyOnField = 0;
		InvokeRepeating(nameof(Spawn), startTimer, spawnTimer);
	}

	void Spawn()
	{
		if (enemyOnField <= maxEnemyOnField)
		{
			GameObject enemy = Instantiate(enemy_Prefab, transform.position,
				Quaternion.identity);
			enemy.GetComponent<SimpleEnemyController>().SetDestination(waypoints);
			enemyOnField++;
		}
	}
}
