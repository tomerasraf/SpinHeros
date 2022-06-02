using UnityEngine;

public class SoundManager : MonoBehaviour
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

    public void PlaySpin_SFX()
    {
        audio.clip = spiningWheelSFX;
        audio.Play();
    }
}