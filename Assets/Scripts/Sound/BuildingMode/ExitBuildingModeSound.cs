using UnityEngine;
using System.Collections;

    public class ExitBuildingModeSound : MonoBehaviour
    {
        [SerializeField] AudioClip exitBuildingModeSound;
        private AudioSource audio;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        public void PlayExitBuildModeSFX_Listener()
        {
            audio.clip = exitBuildingModeSound;
            audio.Play();
        }
    }
