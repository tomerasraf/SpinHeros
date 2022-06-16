using UnityEngine;

class WheelSoundMiniGame : MonoBehaviour
{
    [SerializeField] AudioClip wheelSpiningSound;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayWheelSFX_Listener()
    {
        audio.clip = wheelSpiningSound;
        audio.Play();
    }
}
