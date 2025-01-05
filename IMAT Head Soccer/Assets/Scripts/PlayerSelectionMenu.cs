using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerSelectionMenu : MonoBehaviour
{
    private int index;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI shoot;
    [SerializeField] private TextMeshProUGUI jump;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

        index = PlayerPrefs.GetInt("PlayerIndex");

        if (index > gameManager.players.Count - 1)
        {
            index = 0;
        }

        ChangeScreen();
    }

    private void ChangeScreen()
    {
        PlayerPrefs.SetInt("PlayerIndex", index);
        image.sprite = gameManager.players[index].image;
        nameText.text = gameManager.players[index].name;
        speed.text = gameManager.players[index].moveSpeed.ToString();
        shoot.text = gameManager.players[index].shootForce.ToString();
        jump.text = gameManager.players[index].jumpingForce.ToString();
    }

    public void NextCharacter()
    {
        if (index == gameManager.players.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        ChangeScreen();
    }

    public void PreviousCharacter()
    {
        if (index == 0)
        {
            index = gameManager.players.Count - 1;
        }
        else
        {
            index -= 1;
        }

        ChangeScreen();
    }

    // Guarda el sprite seleccionado para el Jugador 1
    private void Player1()
    {
        if (gameManager != null && gameManager.players.Count > index)
        {
            gameManager.player1 = gameManager.players[index];
        }
    }

    // Guarda el sprite seleccionado para el Jugador 2
    private void Player2()
    {
        if (gameManager != null && gameManager.players.Count > index)
        {
            gameManager.player2 = gameManager.players[index];
        }
    }

    public void SelectPlayer1()
    {
        Player1();  // Guarda la cabeza del Jugador 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        Player2();  // Guarda la cabeza del Jugador 2
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}