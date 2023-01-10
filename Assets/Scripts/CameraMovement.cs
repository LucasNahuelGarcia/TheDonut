using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public Transform pivot;
    public float sensitivity = 1f;
    Controls controls;

    private void Awake() {
        if (pivot == null)
            Debug.LogWarning("No pivot set for camera movement");
        controls = new Controls();
    }

    private void OnEnable() {
        controls.Gameplay.Enable();
        controls.Gameplay.MoveCamera.performed += OnMove;
    }

    private void OnMove(InputAction.CallbackContext context){
        Vector2 value = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {value}");


        this.transform.RotateAround(pivot.position, Vector3.up, value.x * sensitivity);
    }

}
