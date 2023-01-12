using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

namespace TheDonnut.PlayerInteraction
{
    public class PlayerMovement : MonoBehaviour
    {
        public Transform pivot;
        public float sensitivity = 1f;
        Controls controls;
        [SerializeField] CharacterMovement Character;
        [SerializeField] Camera mainCamera;

        private void Awake()
        {
            if (Character == null)
                Debug.LogWarning("No player set");
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
                Character.SetDestination(hit.point);
            }
        }
    }
}