using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void gotomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
