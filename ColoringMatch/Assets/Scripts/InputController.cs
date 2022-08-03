using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    private Camera mainCamera;
    public float minimumDistance = 0.01f;
    private Vector3 previousPosition;
    private Vector3 currentPosition = Vector3.zero;
    private float distanceTraveled;
    
    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if (!Input.GetMouseButton(0)) {
            distanceTraveled = 0;
            return;
        }
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit)) {
            previousPosition = currentPosition == Vector3.zero ? hit.point : currentPosition;
            currentPosition = hit.point;
            distanceTraveled = Vector3.Distance(currentPosition, previousPosition);
        

            if (distanceTraveled < minimumDistance) {
                print("returning");
                return;
            }
            print((distanceTraveled < minimumDistance) + ": " + minimumDistance + " : " + distanceTraveled);

            
            FindObjectOfType<ColorPicker>().HandleClick(hit.collider.gameObject, hit.point);

        }
    }
}