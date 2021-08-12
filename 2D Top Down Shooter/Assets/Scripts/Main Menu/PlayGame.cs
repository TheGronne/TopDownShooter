using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
