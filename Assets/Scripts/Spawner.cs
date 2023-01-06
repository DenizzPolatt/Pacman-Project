using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 minPosition;
    public Vector3 maxPosition;

    private int numberOfSpawns = 5;
    
    void Start()
    {
        spawnFood();
    }

    void spawnFood()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            Instantiate(objectToSpawn, randomPosition(), Quaternion.identity);
        }
    }

    private Vector3 randomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );

        return randomPosition;
    }
}
