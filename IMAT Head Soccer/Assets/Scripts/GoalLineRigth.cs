using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLineRight : MonoBehaviour
{
    public Color goalColor = Color.blue; // Color al detectar el gol
    public GameObject goalEffect;       // Prefab de partículas (opcional)
    private Color originalColor;        // Para restaurar el color original
    private SpriteRenderer spriteRenderer; // SpriteRenderer para cambiar el color

    private void Start()
    {
        // Obtiene el SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Guarda el color original
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra es la pelota
        if (other.CompareTag("Ball"))
        {
            Debug.Log("¡Gol en GoalLineRight!");

            // Cambiar el color de la línea de gol
            if (spriteRenderer != null)
            {
                spriteRenderer.color = goalColor;
                Invoke("ResetColor", 1f); // Restaura el color después de 1 segundo
            }

            // Instanciar el efecto de partículas (si está asignado)
            if (goalEffect != null)
            {
                Instantiate(goalEffect, transform.position, Quaternion.identity);
            }

            // Lógica adicional para indicar un gol (opcional)
        }
    }

    private void ResetColor()
    {
        // Restaura el color original de la línea de gol
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }
}
