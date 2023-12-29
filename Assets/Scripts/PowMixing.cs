using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PowMixing : MonoBehaviour
{
    [SerializeField] private GameBalanceSO items;

    int cherryInPow = 0;
    int mushroomInPow = 0;

    public int productsInPow = 0;
    public int maxProductsInPow;

    float commonMixingHeat;
    float bonusMixingHeat;

    private void Awake()
    {
        maxProductsInPow = items.maxProductsInPow;
        commonMixingHeat = items.mixedSoup;
        bonusMixingHeat = items.perfectSoup;
    }
    float TryMixingPow()
    {
        if (productsInPow >= maxProductsInPow)
        {
            if (cherryInPow >= maxProductsInPow)
            {
                ResetCounters();
                return bonusMixingHeat;
            }
            else if (mushroomInPow >= maxProductsInPow)
            {
                ResetCounters();
                return bonusMixingHeat;
            }
            else
            {
                ResetCounters();
                return commonMixingHeat;
            }
        }
        else
            return 0f;
    }
    public float AddCherryToPow()
    {
        ++cherryInPow;
        ++productsInPow;
        return TryMixingPow();
    }

    public float AddMushroomToPow()
    {
        ++mushroomInPow;
        ++productsInPow;
        return TryMixingPow();
    }
    void ResetCounters()
    {
        productsInPow = 0;
        cherryInPow = 0;
        mushroomInPow = 0;
    }

    
}
