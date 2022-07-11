using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCleaner : MonoBehaviour
{
    [SerializeField] FlyAndAvoidData _flyAndAvoidData;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovment>().transform;
    }

    private void Update()
    {
        if (_flyAndAvoidData.gameIsEnded) { return; }
        transform.position = new Vector3(transform.position.x, player.position.y - 20, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
