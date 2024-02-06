using System.Reflection;
using UnityEditor;
using UnityEngine;

public class SpawnerID : MonoBehaviour
{
    public bool isPickedFromSpawner = false;
    public Spawner originalSpawner; // Spawner, which from taking log
    [SerializeField] public ProductCode productCode;
    public float time;

    private void OnDestroy()
    {
        isPickedFromSpawner = false;
    }
}
