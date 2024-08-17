using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public List<Transform> spawnPoint = new List<Transform>();
    public List<GameObject> spawnPrefabs = new List<GameObject>();

    public void Spawn(int spawnPrefabIndex)
    {
        Spawn(spawnPrefabIndex, 0);
    }
    public void Spawn(int spawnPrefabIndex, int spawnPointIndex)
    {
        Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation);
    }

    // temporary
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spawn(0);

        }
    }
}
