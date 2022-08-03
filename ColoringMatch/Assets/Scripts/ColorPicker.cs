using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour {
    public GameObject brush;
    private static readonly string ColorPaletteTag = "ColorPalette";
    private Color pickedColor = Color.clear;
    private bool picking = false;
    private GameObject drawingCanvas;
    private float Offset = 0.01f;

    private void Start() {
        drawingCanvas = GameObject.FindGameObjectWithTag("DrawingCanvas");
    }


    public void HandleClick(GameObject clickedObject, Vector3 position) {
        picking = clickedObject.CompareTag(ColorPaletteTag);

        if (picking) {
            pickedColor = clickedObject.GetComponent<MeshRenderer>().material.color;
            return;
        }

        if (pickedColor != Color.clear) {
            var splash = Instantiate(brush, position - new Vector3(0, 0, 0), Quaternion.identity, clickedObject.transform);
            splash.transform.localScale = Vector3.one;
            splash.GetComponent<Brush>().SetColor(pickedColor);
            Offset += 0.01f;
        }
    }
    
}