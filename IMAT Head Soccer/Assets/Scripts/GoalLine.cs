using UnityEngine;

public class GoalLine : MonoBehaviour
{
    public Color goalColor = Color.red; // Color al detectar el gol
    public GameObject goalEffect;      // Prefab de part�culas (opcional)
    private Color originalColor;       // Para restaurar el color original
    private Renderer goalRenderer;     // Renderer de la l�nea de gol

    private void Start()
    {
        // Obtiene el Renderer del objeto para cambiar el color
        goalRenderer = GetComponent<Renderer>();
        if (goalRenderer != null)
        {
            originalColor = goalRenderer.material.color; // Guarda el color original
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es la pelota
        if (other.CompareTag("Ball"))
        {
            Debug.Log("�Gol detectado!");

            // Cambiar el color de la l�nea de gol
            if (goalRenderer != null)
            {
                goalRenderer.material.color = goalColor;
                Invoke("ResetColor", 1f); // Restaura el color despu�s de 1 segundo
            }

            // Instanciar el efecto de part�culas (si est� asignado)
            if (goalEffect != null)
            {
                Instantiate(goalEffect, transform.position, Quaternion.identity);
            }
        }
    }

    private void ResetColor()
    {
        // Restaura el color original de la l�nea de gol
        if (goalRenderer != null)
        {
            goalRenderer.material.color = originalColor;
        }
    }
}
