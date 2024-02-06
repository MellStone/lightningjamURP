using System.Collections.Generic;
using UnityEngine;

public class PowMixing : MonoBehaviour
{
    [SerializeField] private GameBalanceSO items;
    [SerializeField] private GameObject[] productImages;
    private Dictionary<ProductCode, int> productInPowCounts = new Dictionary<ProductCode, int>();

    int totalProducts = 0;
    int totalUniqueProducts = 0;
    int maxProductsCount;

    private void Awake()
    {
        maxProductsCount = items.maxProductsInPow;
        InitializeProductInPowCounts();
    }

    void InitializeProductInPowCounts()
    {
        foreach (ProductCode productCode in System.Enum.GetValues(typeof(ProductCode)))
        {
            productInPowCounts[productCode] = 0;
        }
    }

    float TryMixingPow()
    {
        if (totalProducts < maxProductsCount)
        {
            foreach (var kvp in productInPowCounts) // Maybe it can be better but idk :)
            {
                if (kvp.Value == maxProductsCount)  // Checks every product count, if it reached max count in pot - return with bonus
                {
                    ResetCounters();
                    return 20f;
                }
            }
            return 0f; // Nothing's gonna happen, none of the conditions worked.
        }
        else // If reached max total product in pow, but bonus not reached
        {
            ResetCounters();
            return 10f;
        }
    }

    public float AddProductToPow(ProductCode productCode)
    {
        totalProducts++;
        productInPowCounts[productCode]++;
        ShowProductInUI(productCode, productInPowCounts[productCode]);
        return TryMixingPow();
    }

    void ResetCounters()
    {
        totalProducts = 0;
        productInPowCounts.Clear();
        InitializeProductInPowCounts();  // When a Dictionary is cleared, it must be reinitialized again
        ResetImages();
    }

    void ResetImages()
    {
        foreach (var image in productImages)
        {
            image.SetActive(false);
        }
    }

    void ShowProductInUI(ProductCode productCode, int count)
    {
        int index = (int)productCode;
        if (index >= 0 && index < productImages.Length)
        {
            productImages[index].SetActive(count > 0);
        }
    }
}
public enum ProductCode
{
    Berry = 0,
    Mushroom = 1,
    Log = 2
}

