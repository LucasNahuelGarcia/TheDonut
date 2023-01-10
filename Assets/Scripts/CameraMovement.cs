using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class CameraMovement : MonoBehaviour
{
    public Transform pivot;
    public float sensitivity = 1f;
    Controls controls;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Camera mainCamera;

    private void Awake()
    {
        if (navMeshAgent == null)
            Debug.LogWarning("No player set on navMeshAgen ");
        if (pivot == null)
            Debug.LogWarning("No pivot set for camera movement");
        controls = new Controls();
        mainCamera = this.GetComponent<Camera>();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.MoveCamera.performed += OnMove;
        controls.Gameplay.ActionOnPoint.performed += ActionOnPoint;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {value}");


        this.transform.RotateAround(pivot.position, Vector3.up, value.x * sensitivity);
    }


    private void ActionOnPoint(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Debug.Log($"Clicked on: {mousePosition}");
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            navMeshAgent.destination = hit.point;
        }
    }
}
