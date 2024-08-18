using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// simple spawner for 1 type enemy
// for testing purposes
public class SimpleSpawner : MonoBehaviour
{
	public GameObject enemy_Prefab;
	public List<Transform> waypoints;

	// timer for spawner
	public float startTimer = 1.0f;
	public float spawnTimer = 0.5f;

	void Start()
	{
		InvokeRepeating(nameof(Spawn), startTimer, spawnTimer);
	}

	void Spawn()
	{
		GameObject enemy = Instantiate(enemy_Prefab, transform.position,
			Quaternion.identity);
		enemy.GetComponent<EnemyController>().SetDestination(waypoints);
	}
}
