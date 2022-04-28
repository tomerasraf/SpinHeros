using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //1. Detect Player touch the screen.
    //2. Store this postion as the origin.
    //3. Store the current position of the touch.
    //4. calculate the diffrence bettwen the origin to the curent postion of the touch.
    //5. move the position of the camera to diffrence.

    [SerializeField] float cameraSensitivity;
    private Vector3 startTouchPos;
    private Vector3 currentTouchPos;
    private Vector3 difference;
    private Vector3 currentCameraPosition;

    private void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {
                startTouchPos = (Vector3)finger.position;
            }

            if (finger.phase == TouchPhase.Moved)
            {
                currentTouchPos = finger.position;
                difference = (startTouchPos + currentCameraPosition) - currentTouchPos;
                Debug.Log($"Difference: {difference.x}");
                Camera.main.transform.position = new Vector3(difference.x * cameraSensitivity * Time.fixedDeltaTime,
                Camera.main.transform.position.y,
                Camera.main.transform.position.z);
            }

            if (finger.phase == TouchPhase.Ended || finger.phase == TouchPhase.Canceled)
            {
                currentCameraPosition = difference;
            }
        }
    }
}