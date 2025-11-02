using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void QuitGame()
    {
            Application.Quit();
    }
}
