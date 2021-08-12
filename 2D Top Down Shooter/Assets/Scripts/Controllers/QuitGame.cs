using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void quitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
