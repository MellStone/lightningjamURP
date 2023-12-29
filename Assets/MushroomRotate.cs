using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomRotate : MonoBehaviour
{
    [SerializeField] private SpawnerID mushroom;
    bool isRotated = false;
    private void Start()
    {
        mushroom = GetComponent<SpawnerID>();
    }
    void Update()
    {
        if (mushroom.isPickedFromSpawner && isRotated ==false)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, 90f));
            isRotated = true;
        }
    }
}
