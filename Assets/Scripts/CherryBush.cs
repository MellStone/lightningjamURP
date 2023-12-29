using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CherryBush : MonoBehaviour
{
    [SerializeField] private GameObject[] cherryOnModel;
    public Spawner spawner;
    public void ShowCherry(bool state)
    {
        foreach (var cherry in cherryOnModel)
            cherry.SetActive(state);
    }
}
