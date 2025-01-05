using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Player> players;
    public Player player1;  // Para el jugador 1
    public Player player2;  // Para el jugador 2

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectPlayer1(Player player)
    {
        player1 = player;
    }

    public void SelectPlayer2(Player player)
    {
        player2 = player;
    }
}