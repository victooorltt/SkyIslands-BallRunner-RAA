
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string playScene = "MainScene";

    public void PlayGame()
    {
        SceneManager.LoadScene(playScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
