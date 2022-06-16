using UnityEngine;

public class WheelSpinSound : MonoBehaviour
{
    [Header("Wheel Machine Sounds")]
    [SerializeField] AudioClip spiningWheelSFX;

    private AudioSource audio;

    private void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }

    public void PlaySpinSFX_Listener()
    {
        audio.clip = spiningWheelSFX;
        audio.Play();
    }
}