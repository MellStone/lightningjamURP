using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PowMixing : MonoBehaviour
{
    [SerializeField] private GameBalanceSO items;
    [SerializeField] private GameObject[] mushroomImage;
    [SerializeField] private GameObject[] cherryImage;

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
        ShowCherryInUI(cherryInPow);
        return TryMixingPow();
    }

    public float AddMushroomToPow()
    {
        ++mushroomInPow;
        ++productsInPow;
        ShowMushroomInUI(mushroomInPow);
        return TryMixingPow();
    }
    void ResetCounters()
    {
        productsInPow = 0;
        cherryInPow = 0;
        mushroomInPow = 0;
        ResetImages();
    }

    void ResetImages()
    {
        foreach(var cherry in cherryImage)
        {
            cherry.SetActive(false);
        }
        foreach (var mushroom in mushroomImage)
        {
            mushroom.SetActive(false);
        }
    }
    void ShowCherryInUI(int count)
    {
        for (int i = 0; i < cherryImage.Length; i++)
        {
            cherryImage[i].SetActive(i < count);
        }
    }

    void ShowMushroomInUI(int count)
    {
        for (int i = 0; i < mushroomImage.Length; i++)
        {
            mushroomImage[i].SetActive(i < count);
        }
    }
}
