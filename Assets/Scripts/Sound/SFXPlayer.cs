using UnityEngine;

public class SFXPlayer : MonoBehaviour
     { 
        [SerializeField] AudioClip audioClip;
        private AudioSource audio;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        public void PlaySFX_Listener()
        {
            audio.clip = audioClip;
            audio.Play();
        }
}