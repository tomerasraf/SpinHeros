using UnityEngine;
public class SpinClickSoundMiniGame : MonoBehaviour
{
    [Header("Wheel Machine Sounds")]
    [SerializeField] AudioClip spinButtonClickSFX;

    private AudioSource audio;

    private void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }

    public void PlayButtonClickSFX_Listener()
    {
        audio.clip = spinButtonClickSFX;
        audio.Play();
    }
}
