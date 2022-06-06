using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Sound
{
    public class GetHeartSound : MonoBehaviour
    {
        [SerializeField] AudioClip heartSound;
        private AudioSource audio;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        public void PlayBuyingBuildingSFX_Listener()
        {
            audio.clip = heartSound;
            audio.Play();
        }
    }
}