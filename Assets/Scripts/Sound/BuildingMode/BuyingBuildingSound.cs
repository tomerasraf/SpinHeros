using UnityEngine;

public class BuyingBuildingSound : MonoBehaviour
{
    [SerializeField] AudioClip buyingBuildingClip;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayBuyingBuildingSFX_Listener()
    {
        audio.clip = buyingBuildingClip;
        audio.Play();
    }
}
