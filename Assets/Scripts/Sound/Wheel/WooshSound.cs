using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WooshSound : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] AudioClip wooshSound;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playWooshSfX_Listener() {
        audio.clip = wooshSound;
        audio.Play();
    }
}
