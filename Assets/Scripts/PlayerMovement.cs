using UnityEngine;
using UnityEngine.InputSystem;

namespace TheDonnut.PlayerInteraction
{
    public class PlayerMovement : MonoBehaviour
    {
        Controls controls;
        [SerializeField] Camera mainCamera;
        [SerializeField] Transform pivot;
        [SerializeField] float sensitivity = 1f;
        [SerializeField] CharacterMovement Character;

        private void Awake()
        {
            if (Character == null)
                Debug.LogWarning("No player set");
            if (mainCamera == null)
                Debug.LogWarning("No camera set");
            if (pivot == null)
                Debug.LogWarning("No pivot set for camera movement");
            controls = new Controls();
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

            mainCamera.transform.RotateAround(pivot.position, Vector3.up, value.x * sensitivity);
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