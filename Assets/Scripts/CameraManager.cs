using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDonnut.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        public RoomCamera[] roomCameras;
        public Camera CurrentActiveCamera;
        public Transform CurrentPivot;
        public void ChangePlayerCenter(RoomCamera center)
        {
            CurrentActiveCamera = center.Camera;
            CurrentPivot = center.Pivot;

            foreach (RoomCamera camera in roomCameras)
                if (camera == center)
                    camera.EnableCamera();
                else
                    camera.DisableCamera();
        }
    }
}