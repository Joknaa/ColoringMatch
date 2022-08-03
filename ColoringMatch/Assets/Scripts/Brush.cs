using System;
using UnityEngine;

public class Brush : MonoBehaviour {
    public static int sortingOrder = 0;
    public SpriteRenderer spriteRenderer;
    public bool isDisabled;

    
    private void Start() {
        spriteRenderer.sortingOrder = sortingOrder++;
    }

    public void SetColor(Color color) {
        spriteRenderer.material.color = color;
    }

    private void Update() {
        if (spriteRenderer.isVisible) return;
        if (isDisabled) return;
        
        gameObject.SetActive(false);
        isDisabled = true;
    }
}