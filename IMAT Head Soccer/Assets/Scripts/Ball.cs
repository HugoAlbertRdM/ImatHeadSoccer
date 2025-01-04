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

    // M�todo modificado para disparar hacia la izquierda o derecha
    public void ShootBall(bool isPlayer2 = false)
    {
        float angle = Random.Range(15f, 75f);
        float angleInRadians = angle * Mathf.Deg2Rad;

        // Determinar direcci�n del disparo
        float direction = isPlayer2 ? -1f : 1f;  // Player2 dispara a la izquierda

        // Calcular direcci�n del disparo
        Vector2 shootDirection = new Vector2(Mathf.Cos(angleInRadians) * direction, Mathf.Sin(angleInRadians));

        // Aplicar la fuerza al bal�n
        rigitbody2D.velocity = shootDirection * shootForce;

        Debug.Log("Bal�n disparado hacia " + (isPlayer2 ? "izquierda" : "derecha"));
    }
}
