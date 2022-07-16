using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXStop : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void StopSFX_Listener()
    {
        audio.Stop();
    }
}
