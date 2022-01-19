using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Text roundsText;

    public string LoadMenu = "MainMenu";

    void OnEnable()
    {
        roundsText.text = PlayerStat.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(LoadMenu);
    }

}
