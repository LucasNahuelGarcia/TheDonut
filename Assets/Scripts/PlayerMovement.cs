using UnityEngine;
using UnityEngine.InputSystem;
using TheDonnut.Actionables;
using TheDonnut.Cameras;

namespace TheDonnut.PlayerInteraction
{
    public class PlayerMovement : MonoBehaviour
    {
        Controls controls;
        [SerializeField] float sensitivity = 1f;
        [SerializeField] CharacterMovement Character;
        [SerializeField] CameraManager cameraManager;

        private void Awake()
        {
            if (Character == null)
                Debug.LogWarning("No player set");
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

            cameraManager.CurrentActiveCamera.transform.RotateAround(cameraManager.CurrentPivot.position, Vector3.up, value.x * sensitivity);
        }


        private void ActionOnPoint(InputAction.CallbackContext context)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            Debug.Log($"Clicked on: {mousePosition}");
            Ray ray = cameraManager.CurrentActiveCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject objClicked = hit.transform.gameObject;
                Actionable actionable = objClicked.GetComponent<Actionable>();

                if (actionable == null)
                    Character.SetDestination(hit.point);
                else
                    Character.SetDestinationAndActionate(actionable);
            }
        }
    }
}