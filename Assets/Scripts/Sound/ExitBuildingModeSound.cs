using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Sound
{
    public class ExitBuildingModeSound : MonoBehaviour
    {
        [SerializeField] AudioClip exitBuildingModeSound;
        private AudioSource audio;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        public void PlayBuyingBuildingSFX_Listener()
        {
            audio.clip = exitBuildingModeSound;
            audio.Play();
        }
    }
}