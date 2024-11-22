using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float shootForce = 10f;
    private Rigidbody2D rigitbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigitbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBall()
    {
        float angle = Random.Range(15f, 75f);

        float angleInRadians = angle * Mathf.Deg2Rad;
        Vector2 shootDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

        rigitbody2D.velocity = shootDirection * shootForce;
    }
}
