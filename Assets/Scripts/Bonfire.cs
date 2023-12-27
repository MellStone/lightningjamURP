using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bonfire : MonoBehaviour
{
    public event Action<GameObject> OnObjectDestroyed;

    [Range(0f, 100f)] public float fireTime = 100f;
    [Range(0f, 20f)] public float burnerSpeed = 1f;

    [SerializeField] private float logTime = 15f;
    [SerializeField] private Slider heatBar;


    private void Update()
    {
        BurningBonfire();   
        heatBar.value = fireTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Log")
        {
            Destroy(other.gameObject);
            fireTime += logTime;

            OnObjectDestroyed?.Invoke(other.gameObject);
        }
    }

    private void BurningBonfire()
    {
        fireTime -= burnerSpeed * Time.deltaTime;

        //End Game
        if (fireTime < 0)
        {
            SceneManager.LoadScene("EndGameScene");
        }
    }
}
