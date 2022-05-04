using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenTransition : MonoBehaviour
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
            playtopiaBackground_Image.DOColor(Color.white, 2f).OnComplete(() =>
            {
                playtopiaBackground_Image.DOColor(Color.black, 2f).OnComplete(() =>
                {
                    SceneManager.LoadScene(1);
                });
            });
        });
    }
}