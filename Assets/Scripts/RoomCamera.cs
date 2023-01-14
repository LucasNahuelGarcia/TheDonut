using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDonnut.Cameras
{
    public class RoomCamera : MonoBehaviour
    {
        public Camera Camera;
        public Transform Pivot;
        public CameraManager CameraManager;

        private AudioListener listener;

        private void Start()
        {
            listener = Camera.gameObject.GetComponent<AudioListener>();
            listener = listener ?? new AudioListener();
            this.DisableCamera();
        }
        private void OnTriggerEnter(Collider other)
        {
            GameObject otherGameObject = other.transform.gameObject;

            if (otherGameObject.CompareTag("Player"))
                CameraManager.ChangePlayerCenter(this);
        }

        public void DisableCamera()
        {
            listener.enabled = false;
            Camera.enabled = false;
        }
        public void EnableCamera()
        {
            listener.enabled = true;
            Camera.enabled = true;
        }
    }
}