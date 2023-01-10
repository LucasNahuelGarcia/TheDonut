using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Controls controls;
    NavMeshAgent navMeshAgent;
    [SerializeField] Camera mainCamera;
    private void Awake()
    {
        controls = new Controls();
        navMeshAgent = GetComponent<NavMeshAgent>();
        mainCamera = mainCamera ?? Camera.main;
    }

    private void ActionOnPoint(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();

        Debug.Log($"Clicked on: {mousePosition}");
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f))
        {
            navMeshAgent.destination = hit.point;
        }
    }
}
