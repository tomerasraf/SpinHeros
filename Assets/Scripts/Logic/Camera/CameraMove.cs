using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    //1. Detect Player touch the screen.
    //2. Store this postion as the origin.
    //3. Store the current position of the touch.
    //4. calculate the diffrence bettwen the origin to the curent postion of the touch.
    //5. move the position of the camera to diffrence.
    [Header("Data")]
    [SerializeField] WorldData _worldData;

    [Header("Cameras")]
    [SerializeField] GameObject wheelCamera;
    [SerializeField] GameObject worldCamera;
    [SerializeField] GameObject cinemachine;

    [Header("Camera Look at Target")]
    [SerializeField] GameObject cameraTarget;

    [Header("Main Camera Vars")]
    [SerializeField] float cameraSensitivity;
    [SerializeField] float smoothSpeed;
    [SerializeField] float minLimitedValue = -22.875f;
    [SerializeField] float maxLimitedValue = 17.875f;

    private Vector3 EndTouchPosition;



    private void LateUpdate()
    {
        EndTouchPosition = TouchInput.DetectTouchInput(minLimitedValue, maxLimitedValue);
        worldCamera.transform.LookAt(cameraTarget.transform);

        if (_worldData.buldingModeIsOn) { return; }
        MoveCamera();
    }

    public void CameraFocus_ToWheel()
    {
        wheelCamera.SetActive(true);
    }
    public void CameraFocus_ToWorld()
    {
        wheelCamera.SetActive(false);
    }

    public void CameraFocus_BuildMode()
    {
        wheelCamera.SetActive(false);
        EndTouchPosition = Vector3.zero;
        Vector3 worldCameraStartPosition = new Vector3(0, worldCamera.transform.position.y, worldCamera.transform.position.z);
        worldCamera.transform.position = worldCameraStartPosition;
    }

    private void MoveCamera()
    {
        Vector3 smoothedPosition = Vector3.Lerp(worldCamera.transform.position, EndTouchPosition, smoothSpeed);

        Vector3 newCameraPosition = new Vector3(smoothedPosition.x * cameraSensitivity * Time.fixedDeltaTime,
        worldCamera.transform.position.y,
        worldCamera.transform.position.z);
        worldCamera.transform.position = newCameraPosition;
    }
}