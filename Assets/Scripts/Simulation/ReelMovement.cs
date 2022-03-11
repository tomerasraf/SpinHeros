using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelMovement : MonoBehaviour
{
    [SerializeField] float reelSpeed = 3f;
    private bool reelIsMoving;
    private float offset = 70f;

    public void ReelIsMoving()
    {
        reelIsMoving = true;
    }

    public void ReelIsStoped()
    {
        reelIsMoving = false;
    }

    private void Start()
    {
        reelIsMoving = false;

        Vector3 startRotationVector = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            10
            );

        Quaternion startRotation = Quaternion.Euler(startRotationVector);
        transform.rotation = startRotation;
    }

    private void Update()
    {
        if (reelIsMoving)
        {
            ReelSpin();
        }
    }

    public void ReelSpin()
    {
        Vector3 rotationVector = new Vector3(
        transform.eulerAngles.x,
        transform.eulerAngles.y,
        transform.eulerAngles.z + offset * reelSpeed * Time.deltaTime
        );

        Quaternion rotation = Quaternion.Euler(rotationVector);

        transform.rotation = rotation;
    }
}
