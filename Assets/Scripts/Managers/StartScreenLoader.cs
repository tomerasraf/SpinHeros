using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenLoader : MonoBehaviour
{
    [SerializeField] Image playtopiaBackground_Image;

    private void Start()
    {
        StartScreenAnimation();
    }

    private void StartScreenAnimation()
    {
        playtopiaBackground_Image.DOColor(Color.black, 0f).OnComplete(() =>
        {
            playtopiaBackground_Image.DOColor(Color.white, 3.5f).OnComplete(() =>
            {
                playtopiaBackground_Image.DOColor(Color.black, 3.5f).OnComplete(() =>
                {
                    SceneManager.LoadScene(1);
                });
            });
        });
    }
}