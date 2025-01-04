using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Players> players;
    public Sprite player1HeadSprite;  // Para el jugador 1
    public Sprite player2HeadSprite;  // Para el jugador 2

    public Sprite selectedHeadSprite; // ESTO IGUAL DA ERROR

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

    public void SelectPlayer1(Sprite headSprite)
    {
        player1HeadSprite = headSprite;
    }

    public void SelectPlayer2(Sprite headSprite)
    {
        player2HeadSprite = headSprite;
    }
}
