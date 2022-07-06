using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float cameraYPosOffset;
    [SerializeField] float cameraSmooth;
    [SerializeField] float currentVelocity;

    private Transform player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovment>().transform;
    }

    private void LateUpdate()
    {
       // float velocity = Mathf.SmoothDamp(transform.position.y, player.position.y + cameraYPosOffset , ref currentVelocity, cameraSmooth);
        transform.position = new Vector3(transform.position.x, player.position.y + cameraYPosOffset, transform.position.z);
    }
}
