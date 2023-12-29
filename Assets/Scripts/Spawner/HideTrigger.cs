using UnityEngine;

public class HideTrigger : MonoBehaviour
{
    private SpawnerID obj;
    private SphereCollider sphereCollider;
    private BoxCollider boxCollider;
    bool changedOnce = false;
    private void Start()
    {
        obj = GetComponent<SpawnerID>();
        sphereCollider = GetComponent<SphereCollider>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (obj.isPickedFromSpawner && !changedOnce)
        {
            sphereCollider.enabled = false;
            boxCollider.isTrigger = true;

            changedOnce = true;
        }
    }
}
