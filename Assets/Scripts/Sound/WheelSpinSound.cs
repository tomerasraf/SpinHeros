using UnityEngine;

public class WheelSpinSound : MonoBehaviour
{
    [Header("Wheel Machine Sounds")]
    [SerializeField] AudioClip spiningWheelSFX;

    [Header("Data")]
    [SerializeField] PlayerData _playerData;

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