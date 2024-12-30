using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelectionMenu : MonoBehaviour
{
    private int index;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
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

    public void SelectPlayer1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
