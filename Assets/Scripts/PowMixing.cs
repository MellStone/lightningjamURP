using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowMixing : MonoBehaviour
{
    int cherryInPow = 0;
    int mushroomInPow = 0;

    public int productsInPow = 0;
    public int maxProductsInPow = 2;

    float commonMixingHeat = 20f;
    float bonusMixingHeat = 25f;

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
