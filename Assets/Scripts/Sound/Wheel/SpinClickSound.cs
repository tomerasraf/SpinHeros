using UnityEngine;

public class SpinClickSound : MonoBehaviour
{
    [Header("Wheel Machine Sounds")]
    [SerializeField] AudioClip buttonClickSFX;

    private AudioSource audio;

    private void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }

    public void PlayButtonClickSFX_Listener()
    {
        audio.clip = buttonClickSFX;
        audio.Play();
    }
}