using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Va a tener el control de que spawns estan activos en base a las areas desbloqueadas
/// Es el que spawneara a los zombies cada N tiempo
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Area[] areas;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject hellhoundPrefab;

    [SerializeField, Tooltip("Tiempo en el que apareceran los zombies")] 
    private float totalSpawnTime = 19f;

    [SerializeField,Tooltip("Tiempo entre spawn cada zombie")] private float spawnRate;

    [SerializeField] private List<Transform> spawnPoint;

    public void StartSpawning(int zombiesToSpawn)
    {
        
        Debug.Log($"Se van a spawnear {zombiesToSpawn} zombies");
        spawnRate = totalSpawnTime / zombiesToSpawn;
        StartCoroutine(SpawnZombies(zombiesToSpawn));
    }


    private Transform zParent;
    
    IEnumerator SpawnZombies(int zombiesToSpawn)
    {
        try
        {
            zParent = GameObject.Find("Zombies").transform;
        }
        catch
        {
            zParent = Instantiate(new GameObject(), transform.position, default).transform;
            zParent.name = "Zombies";

        }
        
        Transform parent = GameObject.Find("Zombies").transform;
        for(int i = 0; i < zombiesToSpawn; i++)
        {
            Debug.Log("Se spawnea el zombie " + (i + 1));
            GameObject zombie = Instantiate(zombiePrefab, RandomSpawn());
            zombie.name = "Zombie " + (i+1);
            zombie.transform.parent = parent;
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private Transform RandomSpawn()
    {
        int randomTransform = Random.Range(0,spawnPoint.Count);
        return spawnPoint[randomTransform];
    }

}
