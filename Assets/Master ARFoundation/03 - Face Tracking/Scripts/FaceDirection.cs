using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARCameraManager))]
public class FaceDirection : MonoBehaviour
{
    private ARCameraManager _arCameraManager;

    private void Start()
    {
        _arCameraManager = GetComponent<ARCameraManager>();
    }

    public void ChangeToFront()
    {

        _arCameraManager.requestedFacingDirection = CameraFacingDirection.User;
    }

    public void ChangeToBack()
    {

        _arCameraManager.requestedFacingDirection = CameraFacingDirection.World;
    }
}
