using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI result;

    void Start()
    {
        if (MatchManager.result == "D")
        {
            result.text = "It's a draw!!!";  // Actualizar el texto del componente
        }
        else if (MatchManager.result == "1")
        {
            result.text = "Player 1 won!!!";  // Actualizar el texto del componente
        }
        else
        {
            result.text = "Player 2 won!!!";  // Actualizar el texto del componente
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);  // Cargar la escena 0
    }

    public void Exit()
    {
        // Si el juego está corriendo en el editor
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;  // Detener el modo de juego en el editor
#else
        Application.Quit();  // Salir del juego en una versión compilada
#endif

        Debug.Log("Exiting the game...");
    }
}
