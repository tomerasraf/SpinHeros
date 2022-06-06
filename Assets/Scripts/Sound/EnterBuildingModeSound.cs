using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Sound
{
    public class EnterBuildingModeSound : MonoBehaviour
    {
        [SerializeField] AudioClip enterBuildingModeSound;
        private AudioSource audio;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        public void PlayBuyingBuildingSFX_Listener()
        {
            audio.clip = enterBuildingModeSound;
            audio.Play();
        }
    }
}