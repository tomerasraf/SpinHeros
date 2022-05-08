using UnityEngine;

public class TouchInput
{
    public static Vector3 startTouchPosition;
    public static Vector3 endTouchPosition;
    public static Vector3 currentTouchPos;
    public static Vector3 difference;
    public static Vector3 DetectTouchInput(float minLimitedValue, float maxLimitedValue)
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {
                startTouchPosition = finger.position;
                //Debug.Log(startTouchPosition + "Start");
            }

            if (finger.phase == TouchPhase.Moved)
            {
                currentTouchPos = finger.position;
                //Debug.Log(currentTouchPos + "Current");

                difference = (startTouchPosition + endTouchPosition) - currentTouchPos;
                //Debug.Log(difference + "Diff");

                difference = new Vector3(Mathf.Clamp(difference.x, minLimitedValue, maxLimitedValue), difference.y, difference.z);
            }

            if (finger.phase == TouchPhase.Ended || finger.phase == TouchPhase.Canceled)
            {
                endTouchPosition = difference;
                //Debug.Log(endTouchPosition + "End");
            }
        }

        return difference;
    }
}