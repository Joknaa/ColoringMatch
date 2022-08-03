using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour {
    private static readonly string ColorPaletteTag = "ColorPalette";
    private Color pickedColor = Color.clear;
    private bool picking = false;

    
    public void HandleClick(GameObject clickedObject) {
        picking = clickedObject.CompareTag(ColorPaletteTag);
        
        
        if (picking) {
            pickedColor = clickedObject.GetComponent<MeshRenderer>().material.color;
            return;
        }
        
        if (pickedColor != Color.clear) clickedObject.GetComponent<MeshRenderer>().material.color = pickedColor;
    }
    
}