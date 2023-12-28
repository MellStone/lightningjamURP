using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ModelToSpawn; // Spawning prefab
    private float spawnInterval = 10f; // Interval spawn in seconds


    [SerializeField] private bool isCherry;

    private bool isSpawned = true;
    // For upscaling - for now not needed
    // List to track spawned objects
    // private List<GameObject> spawnedObjects = new List<GameObject>();
    void Spawn()
    {
        
        if (!isSpawned)
        {
            // Creating new Object
            GameObject newSpawnObject = Instantiate(ModelToSpawn, transform.position, Quaternion.identity);
            SpawnerID createdObject = newSpawnObject.GetComponent<SpawnerID>();

            if (createdObject != null)
            {
                // Link "Spawner ID" to Created Objected
                createdObject.originalSpawner = this;
            }

            // Parenting to Spawner Object
            newSpawnObject.transform.parent = transform;
        }
    }

    public void RemoveObject(GameObject modelToRemove)
    {
        // For upscaling
        // Remove the object from the list
        // spawnedObjects.Remove(modelToRemove);

        isSpawned = false;
        Destroy(modelToRemove);
        
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(spawnInterval);
        Spawn();
    }
}
