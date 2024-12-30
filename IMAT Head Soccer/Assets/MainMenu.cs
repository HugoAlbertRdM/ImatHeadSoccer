using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SinglePlayer()
    {
        PlayerPrefs.SetString("GameMode", "SinglePlayer");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MultiplePlayer()
    {
        PlayerPrefs.SetString("GameMode", "Multiplayer");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
