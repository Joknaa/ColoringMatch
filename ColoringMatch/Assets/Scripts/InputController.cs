using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    private Camera mainCamera;
    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if (!Input.GetMouseButtonDown(0)) return;

        var position = Input.mousePosition;
        var ray = mainCamera.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out var hit)) {
            FindObjectOfType<ColorPicker>().HandleClick(hit.collider.gameObject);

        }
    }
}