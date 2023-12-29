using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;

public class CherryBush : MonoBehaviour
{
    [SerializeField] private GameObject[] cherryOnModel;

    public Spawner spawner;
    private void Update()
    {
        IsCherryVisible();
    }
    public void ShowCherry(bool state)
    {
        foreach (var cherry in cherryOnModel)
            cherry.SetActive(state);
    }
    public void IsCherryVisible()
    {
        if (spawner.spawnedObjects.Count != 0)
        {
            foreach (var sp in spawner.spawnedObjects)
            {
                if (sp.TryGetComponent<SpawnerID>(out SpawnerID iD))
                {
                    if (iD.isPickedFromSpawner == false)
                    {
                        ShowCherry(true);
                        return;
                    }
                    else if (iD.isPickedFromSpawner)
                    {
                        ShowCherry(false);
                    }
                }
            }
        }
    }
}
