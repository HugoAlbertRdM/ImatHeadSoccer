using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro; // Si usas TextMeshPro

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance; // Singleton para facilitar el acceso global

    [SerializeField] private TMP_Text leftScoreText;  // Texto para mostrar los goles del jugador 1
    [SerializeField] private TMP_Text rightScoreText; // Texto para mostrar los goles del jugador 2
    [SerializeField] private TMP_Text timerText;      // Texto para mostrar el tiempo restante

    [SerializeField] private float matchDuration = 60f; // Duración del partido en segundos

    private int leftScore = 0;  // Puntuación del jugador 1
    private int rightScore = 0; // Puntuación del jugador 2
    private float timeRemaining;

    public static string result;
    private bool isMatchActive = true;

    private GameObject player1;
    private PlayerController playerController1;
    private GameObject player2;
    private PlayerController playerController2;

    void Awake()
    {
        // Configurar Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timeRemaining = matchDuration;
        UpdateScoreUI();
        UpdateTimerUI();

        // Encuentra los jugadores y asigna sus componentes PlayerController
        player1 = GameObject.FindGameObjectWithTag("Player1");
        playerController1 = player1.GetComponent<PlayerController>();

        player2 = GameObject.FindGameObjectWithTag("Player2");
        playerController2 = player2.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (isMatchActive)
        {
            // Reducir el tiempo restante
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0f)
            {
                timeRemaining = 0f;
                EndMatch();
            }

            UpdateTimerUI();
            UpdateScoreUI();
        }
    }

    public void GoalScored(string goalTag)
    {
        if (!isMatchActive) return;

        if (goalTag == "GoalZoneLeft")
        {
            rightScore++; // Gol para el jugador de la derecha
            ResetGame();
        }
        else if (goalTag == "GoalZoneRight")
        {
            leftScore++; // Gol para el jugador de la izquierda
            ResetGame();
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (leftScoreText != null)
        {
            leftScoreText.text = leftScore.ToString();
        }

        if (rightScoreText != null)
        {
            rightScoreText.text = rightScore.ToString();
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            // Formato de minutos:segundos
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    private void ResetGame()
    {
        // Reinicia posiciones de jugadores y balón
        GameObject ball = GameObject.FindWithTag("Ball");
        if (ball != null)
        {
            ball.transform.position = Vector3.zero;
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                ballRb.velocity = Vector2.zero;
            }
        }

        playerController1.StartPosition();
        playerController2.StartPosition();

    }

    private void EndMatch()
    {
        isMatchActive = false;

        string winnerMessage = "It's a Draw!";
        if (leftScore > rightScore)
        {
            winnerMessage = "Left Player Wins!";
            result = "P1";
        }
        else if (rightScore > leftScore)
        {
            winnerMessage = "Right Player Wins!";
            result = "P2";
        }
        else
        {
            result = "D";
        }

        Debug.Log(winnerMessage);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}