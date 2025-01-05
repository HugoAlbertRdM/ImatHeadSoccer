using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    private string gameMode;

    void Start()
    {
        gameMode = PlayerPrefs.GetString("GameMode", "SinglePlayer"); // Por defecto, SinglePlayer
        Debug.Log("Selected Mode: " + gameMode);

        if (gameMode == "SinglePlayer")
        {
            // Lógica para jugar contra la IA
            Debug.Log("Starting Single Player Mode...");
        }
        else if (gameMode == "Multiplayer")
        {
            // Lógica para multijugador
            Debug.Log("Starting Multiplayer Mode...");
        }
    }
}