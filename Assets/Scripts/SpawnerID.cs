using System.Reflection;
using UnityEditor;
using UnityEngine;

public class SpawnerID : MonoBehaviour
{
    public bool isPickedFromSpawner = false;
    public Spawner originalSpawner; // Spawner, which from taking log

    private void OnDestroy()
    {
        isPickedFromSpawner = false;
    }
}
