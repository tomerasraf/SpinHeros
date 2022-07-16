using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayerOnce : MonoBehaviour
{

    [SerializeField] AudioClip audioClip;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlaySFXOnce_Listener()
    {
        audio.clip = audioClip;
        audio.PlayOneShot(audioClip);
    }
}
