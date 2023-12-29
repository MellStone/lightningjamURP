using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Campfire : MonoBehaviour
{
    public event Action<GameObject> OnObjectDestroyed;

    [Range(0f, 100f)] public float fireTime = 100f;
    [SerializeField] private float maxFireTime = 100f;
    [Range(0f, 20f)] public float burnerSpeed = 1f;

    [SerializeField] private float logTime = 15f;

    [SerializeField] private PowMixing pow;
    [SerializeField] private Slider heatBar;


    private void Update()
    {
        BurningBonfire();   
        heatBar.value = fireTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checking if has component SpawnerID
        if (other.TryGetComponent<SpawnerID>(out SpawnerID objectInHands))
        {
            // Refer to the spawner where the object was taken from
            Spawner Spawner = objectInHands.originalSpawner;
            if (other.tag == "Log")
            {
                // Transfer obj to remove and spawn a new one
                Spawner.RemoveObject(other.gameObject);
                OnObjectDestroyed?.Invoke(other.gameObject);

                AddToFireTimer(logTime);
            }
        

            if (other.tag == "Cherry")
            {
                Spawner.RemoveObject(other.gameObject);
                OnObjectDestroyed?.Invoke(other.gameObject);

                AddToFireTimer(pow.AddCherryToPow());
            }
            if (other.tag == "Mushroom")
            {
                Spawner.RemoveObject(other.gameObject);
                OnObjectDestroyed?.Invoke(other.gameObject);

                AddToFireTimer(pow.AddMushroomToPow());

            }
        }
    }
    private void AddToFireTimer(float countToAdd)
    {
        fireTime += countToAdd;
        if (fireTime > maxFireTime)
            fireTime = maxFireTime;
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
