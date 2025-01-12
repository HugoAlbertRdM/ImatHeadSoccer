using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int jumpCount = 0;
    private int maxJumps = 2;
    private float proximityThreshold = 2f;
    private bool isAIPlayer2;

    // Components
    private Rigidbody2D rigitbody2D;
    private GameObject head;
    private GameObject shoe;
    private GameObject ballGameObject;
    private Ball ballScript;
    private Animator animator;

    // Player stats
    private float jumpingForce;
    private float moveSpeed;
    private float shootForce;

    [SerializeField] private GameObject headObject;  // Referencia a la cabeza para cambiar el sprite
    [SerializeField] private Vector2 startPositionPlayer1 = new Vector2(-6f, -2f);  // Posición inicial Player 1
    [SerializeField] private Vector2 startPositionPlayer2 = new Vector2(6f, -2f);   // Posición inicial Player 2

    // Start is called before the first frame update
    void Start()
    {
        rigitbody2D = GetComponent<Rigidbody2D>();
        head = transform.Find("Head")?.gameObject;
        shoe = transform.Find("Shoe")?.gameObject;
        ballGameObject = GameObject.FindWithTag("Ball");
        ballScript = ballGameObject != null ? ballGameObject.GetComponent<Ball>() : null;
        animator = GetComponent<Animator>();

        // Asignar las características del jugador
        if (gameObject.name == "Player1" && GameManager.Instance.player1 != null)
        {
            jumpingForce = GameManager.Instance.player1.jumpingForce;
            moveSpeed = GameManager.Instance.player1.moveSpeed;
            shootForce = GameManager.Instance.player1.shootForce;
        }
        else if (gameObject.name == "Player2" && GameManager.Instance.player2 != null)
        {
            jumpingForce = GameManager.Instance.player2.jumpingForce;
            moveSpeed = GameManager.Instance.player2.moveSpeed;
            shootForce = GameManager.Instance.player2.shootForce;
        }

        StartPosition();

        // Cambiar la cabeza según el jugador
        if (headObject != null && GameManager.Instance != null)
        {
            SpriteRenderer headRenderer = headObject.GetComponent<SpriteRenderer>();

            if (gameObject.name == "Player1" && GameManager.Instance.player1 != null)
            {
                headRenderer.sprite = GameManager.Instance.player1.image;
            }
            else if (gameObject.name == "Player2" && GameManager.Instance.player2 != null)
            {
                headRenderer.sprite = GameManager.Instance.player2.image;
            }
        }

        // Determinar si el jugador es controlado por IA o no
        string gameMode = PlayerPrefs.GetString("GameMode", "SinglePlayer");
        if (gameObject.name == "Player2" && gameMode == "SinglePlayer")
        {
            isAIPlayer2 = true;
        }
        else
        {
            isAIPlayer2 = false;
        }
    }

    void Update()
    {
        if (gameObject.name == "Player1")
        {
            Player1Controls();
        }
        else if (gameObject.name == "Player2")
        {
            if (isAIPlayer2)
            {
                AIControls();
            }
            else
            {
                Player2Controls();
            }
        }
    }

    private void Player1Controls()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rigitbody2D.velocity = new Vector2(moveInput * moveSpeed, rigitbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            rigitbody2D.AddForce(new Vector2(0, jumpingForce));
            jumpCount++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Player2Controls()
    {
        float moveInput = Input.GetAxis("Horizontal2");
        rigitbody2D.velocity = new Vector2(moveInput * moveSpeed, rigitbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJumps)
        {
            rigitbody2D.AddForce(new Vector2(0, jumpingForce));
            jumpCount++;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    private void AIControls()
    {
        // Obtener la posición del balón
        Vector2 ballPosition = ballGameObject.transform.position;

        // Determinar la dirección hacia el balón
        float direction = ballPosition.x > transform.position.x ? 1 : -1;

        // Movimiento horizontal hacia el balón
        if (Mathf.Abs(ballPosition.x - transform.position.x) > proximityThreshold) // Si el balón está lejos
        {
            rigitbody2D.velocity = new Vector2(direction * moveSpeed, rigitbody2D.velocity.y);
        }
        else
        {
            // Detenerse cuando esté cerca del balón
            rigitbody2D.velocity = new Vector2(0, rigitbody2D.velocity.y);
        }

        // Saltar si el balón está más alto y la IA no ha alcanzado el máximo de saltos
        if (ballPosition.y > transform.position.y + 0.5f && jumpCount < maxJumps)
        {
            rigitbody2D.AddForce(new Vector2(0, jumpingForce));
            jumpCount++;
        }

        // Intentar disparar si está cerca del balón
        if (IsNearBall())
        {
            Shoot();
        }

        // Ajustar la posición para no quedarse atascado en los límites del campo
        if (transform.position.x < -7f) // Límite izquierdo
        {
            rigitbody2D.velocity = new Vector2(moveSpeed, rigitbody2D.velocity.y); // Moverse hacia la derecha
        }
        else if (transform.position.x > 7f) // Límite derecho
        {
            rigitbody2D.velocity = new Vector2(-moveSpeed, rigitbody2D.velocity.y); // Moverse hacia la izquierda
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }

    bool IsNearBall()
    {
        if (shoe == null || ballGameObject == null) return false;

        float distance = Vector2.Distance(shoe.transform.position, ballGameObject.transform.position);
        return distance < proximityThreshold;
    }

    void Shoot()
    {
        if (animator != null)
        {
            animator.SetTrigger("shootOnce");
        }

        if (IsNearBall())
        {
            // Pasamos true si es Player2
            bool isPlayer2 = gameObject.name == "Player2";
            ballScript.ShootBall(shootForce, isPlayer2);
        }
    }

    public void StartPosition()
    {
        // Posicionar jugadores en lados opuestos
        if (gameObject.name == "Player1")
        {
            transform.position = startPositionPlayer1;
        }
        else if (gameObject.name == "Player2")
        {
            transform.position = startPositionPlayer2;
        }
    }
}