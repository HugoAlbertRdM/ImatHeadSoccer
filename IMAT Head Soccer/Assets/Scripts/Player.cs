using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpingForce;
    private float moveSpeed = 5f;
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

    // Start is called before the first frame update
    void Start()
    {
        rigitbody2D = GetComponent<Rigidbody2D>();
        head = transform.Find("Head").gameObject;
        shoe = transform.Find("Shoe").gameObject;
        ballGameObject = GameObject.FindWithTag("Ball");
        ballScript = ballGameObject.GetComponent<Ball>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    // Actualize with events
    void Update()
    {
        // Movement
        float moveInput = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveInput * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            rigitbody2D.AddForce(new Vector2(0, jumpingForce));
            jumpCount++;
        }

        // Shoot Ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("shootOnce");
            if (IsNearBall())
            {
                ballScript.ShootBall();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpCount = 0;
        }
    }

    bool IsNearBall()
    {
        float distance = Vector2.Distance(shoe.transform.position, ballGameObject.transform.position);

        return distance < proximityThreshold;
    }
}