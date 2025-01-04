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
        if (GameManager.Instance != null && GameManager.Instance.selectedHeadSprite != null)
        {
            spriteRenderer.sprite = GameManager.Instance.selectedHeadSprite;
        }
    }
}


