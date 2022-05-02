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
    private Vector3 startTouchPos;
    private Vector3 currentTouchPos;
    private Vector3 difference;
    private Vector3 currentCameraPosition;


    private void LateUpdate()
    {
        worldCamera.transform.LookAt(cameraTarget.transform);
        CameraMovement();
    }

    public void CameraFocus_ToWheel()
    {
        StartCoroutine(cameraFocusCoroutine());
    }

    IEnumerator cameraFocusCoroutine()
    {
        cinemachine.GetComponent<CinemachineBrain>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        wheelCamera.SetActive(true);

        yield return null;
    }

    private void CameraMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {
                startTouchPos = finger.position;
            }

            if (finger.phase == TouchPhase.Moved)
            {
                currentTouchPos = finger.position;

                difference = (startTouchPos + currentCameraPosition) - currentTouchPos;

                difference = new Vector3(Mathf.Clamp(difference.x, minLimitedValue, maxLimitedValue), difference.y, difference.z);

                MoveCamera();

            }

            if (finger.phase == TouchPhase.Ended || finger.phase == TouchPhase.Canceled)
            {
                currentCameraPosition = difference;
            }
        }
    }

    private void MoveCamera()
    {
        Vector3 smoothedPosition = Vector3.Lerp(worldCamera.transform.position, difference, smoothSpeed);

        Vector3 newCameraPosition = new Vector3(smoothedPosition.x * cameraSensitivity * Time.fixedDeltaTime,
        worldCamera.transform.position.y,
        worldCamera.transform.position.z);
        worldCamera.transform.position = newCameraPosition;
    }
}