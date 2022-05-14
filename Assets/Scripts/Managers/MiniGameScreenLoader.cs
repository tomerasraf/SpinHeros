using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class MiniGameScreenLoader : MonoBehaviour
{
    [SerializeField] GameObject background_Image;
    [SerializeField] VoidEvent startCountDown;
    [SerializeField] GameObject[] portals;

    IEnumerator Start()
    {
        FadeOutTransition();
        yield return null;
    }

    private void FadeOutTransition()
    {
        background_Image.SetActive(true);
        background_Image.GetComponent<Image>().DOFade(0, 1.5f).OnComplete(() =>
        {
            background_Image.SetActive(false);
            foreach (GameObject portal in portals)
            {
                portal.SetActive(false);
            }
            startCountDown.Raise();
        });
    }

    public void MiniGameHasEnded_Listener()
    {
        SceneTransitionToWorld_Coroutine();
    }

    private void SceneTransitionToWorld_Coroutine()
    {
        background_Image.SetActive(true);
        background_Image.GetComponent<Image>().DOFade(1, 1.5f).OnComplete(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
}