using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFireUI : MonoBehaviour
{
    [SerializeField] private GameObject[] images;
    int showed = 0;
    
    public void ShowMinutePassedSprite()
    {
        if (images.Length - 1 > showed)
        {
            images[showed].SetActive(true);
            showed++;
        }
    }
}
