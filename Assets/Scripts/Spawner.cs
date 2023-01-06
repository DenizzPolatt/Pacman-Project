using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    
    void Start()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );
        
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}
