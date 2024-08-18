using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spawner for multiple enemies
public class Spawner : MonoBehaviour
{
	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float spawnRate;
		public int spawn_Point;
	}

	public enum State
	{
		SPAWNING,
		WAITING,
		TIMING
	}
	public State state = State.TIMING;

	public List<Transform> spawnPoints;

	public List<Wave> waves;
	private int nextWave = 0;

	public float timeToNextWave;
	public float countDown;
	private float waitTime = 1.0f;

	void Start()
	{
		if (spawnPoints.Count == 0)
		{
			Debug.LogError("no spawn point");
		}

		countDown = timeToNextWave;
	}

	void Update()
	{
		if (state == State.WAITING)
		{
			// check whether enemies are still left
			if (!EnemyAlive())
			{
				// start new round
				WaveComplete();
			}
			else
			{
				// continue the game
				return;
			}
		}

		if (countDown <= 0)
		{
			if (state != State.SPAWNING)
			{
				// start spawning
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
		}
		else
		{
			countDown -= Time.deltaTime;
		}
	}

	bool EnemyAlive()
	{
		waitTime -= Time.deltaTime;

		if (waitTime <= 0f)
		{
			waitTime = 1.0f;

			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}

		return true;
	}

	void WaveComplete()
	{
		Debug.Log("Wave complete");
		state = State.TIMING;
		countDown = timeToNextWave;

		if (nextWave + 1 > waves.Count - 1)
		{
			// Stage completes
			Debug.Log("All waves complete");
		}
		else
		{
			nextWave++;
		}
	}

	void SpawnEnemy(Transform enemy, Transform sp)
	{
		//GameObject enemy = Instantiate(enemy_Prefab, transform.position,
		//	Quaternion.identity);
		//enemy.GetComponent<EnemyController>().SetDestination(waypoints);

		Instantiate(enemy, sp.position, Quaternion.identity);
	}

	Transform GetSpawnPoint(Wave wave)
	{
		switch (wave.spawn_Point)
		{
			case 0:
				return spawnPoints[0];
			case 1:
				return spawnPoints[1];
			default:
				return spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
		}
	}

	IEnumerator SpawnWave(Wave wave)
	{
		state = State.SPAWNING;

		for (int i = 0; i < wave.count; i++)
		{
			Transform sp = GetSpawnPoint(wave);
			SpawnEnemy(wave.enemy, sp);
			yield return new WaitForSeconds(1f / wave.spawnRate);
		}

		state = State.WAITING;
	}
}