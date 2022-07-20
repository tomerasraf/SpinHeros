using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Image backgroundImage;

    void Start()
    {
        BackgroundFadeIn();
    }

    public void EndGame_Listener() {
        BackgroundfadeOutToWheel();
    }

    private void BackgroundfadeOutToWheel() {
        backgroundImage.DOFade(0, 0).OnComplete(() =>
        {
            backgroundImage.enabled = true;
            backgroundImage.DOFade(1, 1).OnComplete(() => {
                SceneManager.LoadScene(2);
            });
        });
    }
    private void BackgroundFadeIn()
    {
        backgroundImage.DOFade(1, 0).OnComplete(() =>
        {
            backgroundImage.DOFade(0, 1);
            backgroundImage.enabled = false;
        });
    }
}
