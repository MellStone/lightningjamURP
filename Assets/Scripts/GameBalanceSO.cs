using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameBalance", menuName = "ScriptableObjects/GameBalanceSO", order = 1)]
public class GameBalanceSO : ScriptableObject
{
    [Header("Heat Generating Items")]
    public float log = 10f;
    public float perfectSoup = 25f;
    public float mixedSoup = 20f;

    [Space]
    [Header("Campfire settings")]
    public float maxHeatCount = 100f;
    public float heatDropRate = 1f;

    [Space]
    [Header("Pow settings")]
    public int maxProductsInPow = 2;

    [Space]
    [Header("Spawner settings")]
    public float spawnIntervals = 10f;
    [Space]
    public float minSpawnIntervals = 8f;
    public float maxSpawnIntervals = 15f;

}
