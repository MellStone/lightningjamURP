using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string GameScene;
    public void TryAgain()
    {
        SceneManager.LoadScene(GameScene);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
