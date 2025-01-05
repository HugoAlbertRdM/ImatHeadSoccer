using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpingForce = 150f;
    private float moveSpeed = 5f;
    public float shootForce = 10f;
    private int jumpCount = 0;
    private int maxJumps = 2;
    private float proximityThreshold = 2f;

    // Components
    private Rigidbody2D rigitbody2D;
    private GameObject head;
    private GameObject shoe;
    private GameObject ballGameObject;
    private Ball ballScript;
    private Animator animator;

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

        StartPosition();

        // Cambiar la cabeza según el jugador
        if (headObject != null && GameManager.Instance != null)
        {
            SpriteRenderer headRenderer = headObject.GetComponent<SpriteRenderer>();

            if (gameObject.name == "Player1" && GameManager.Instance.player1HeadSprite != null)
            {
                headRenderer.sprite = GameManager.Instance.player1HeadSprite;
            }
            else if (gameObject.name == "Player2" && GameManager.Instance.player2HeadSprite != null)
            {
                headRenderer.sprite = GameManager.Instance.player2HeadSprite;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Player 1 Controls
        if (gameObject.name == "Player1")
        {
            float moveInput = Input.GetAxis("Horizontal");
            rigitbody2D.velocity = new Vector2(moveInput * moveSpeed, rigitbody2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
            {
                rigitbody2D.AddForce(new Vector2(0, jumpingForce));
                jumpCount++;
            }

            // Disparo para Player1 (Espacio)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

        // Player 2 Controls (WASD)
        if (gameObject.name == "Player2")
        {
            float moveInput = Input.GetAxis("Horizontal2");
            rigitbody2D.velocity = new Vector2(moveInput * moveSpeed, rigitbody2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJumps)
            {
                rigitbody2D.AddForce(new Vector2(0, jumpingForce));
                jumpCount++;
            }

            // Disparo para Player2 (Letra E)
            if (Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

            Debug.Log(gameObject.name + " ha disparado el balón hacia " + (isPlayer2 ? "izquierda" : "derecha"));
        }
        else
        {
            Debug.Log("Fuera de rango para chutar.");
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
