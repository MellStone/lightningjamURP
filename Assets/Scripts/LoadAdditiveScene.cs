using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAdditiveScene : MonoBehaviour
{
    [SerializeField] private string sceneName = "MainMenu";
    private void Awake()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
