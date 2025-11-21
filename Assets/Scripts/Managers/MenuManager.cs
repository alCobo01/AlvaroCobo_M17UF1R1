using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
            Application.Quit();
    }
}
