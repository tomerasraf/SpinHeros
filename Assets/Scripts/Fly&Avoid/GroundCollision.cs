using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    [SerializeField] FlyAndAvoidIntro _flyAndAvoidIntro;
    [SerializeField] GameObject explotionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {

          GameObject explostionEffectClone = Instantiate(explotionEffect, other.transform.position, Quaternion.identity);
            Destroy(_flyAndAvoidIntro.meteorCopy);
            Destroy(explostionEffectClone, 3);
        }
    }
}
