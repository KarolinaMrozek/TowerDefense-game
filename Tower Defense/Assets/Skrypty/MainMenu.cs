using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string LevelToLoad = "MainScene";

    public void Play()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();

    }

}
