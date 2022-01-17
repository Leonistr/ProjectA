using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesgt : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer.color = new Color(0, 0, 0, 0);
    }
}
