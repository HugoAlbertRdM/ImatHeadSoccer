using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Head : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Verifica si hay un sprite seleccionado y lo aplica
        if (GameManager.Instance != null)
        {
            SpriteRenderer headRenderer = GetComponent<SpriteRenderer>();

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
}

