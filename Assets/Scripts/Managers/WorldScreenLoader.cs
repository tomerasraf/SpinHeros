using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WorldScreenLoader : MonoBehaviour
{
    [SerializeField] GameObject background_Object;

    private void Start()
    {
        background_Object.SetActive(true);
        background_Object.GetComponent<Image>().DOFade(1, 0);
        background_Object.GetComponent<Image>().DOFade(0, 1.5f).OnComplete(() =>
        {
            background_Object.SetActive(false);
        });

    }

    public void MiniGameTransition_Listener()
    {
        StartCoroutine(SceneTransitionToMiniGame_Coroutine());
    }

    IEnumerator SceneTransitionToMiniGame_Coroutine()
    {
        background_Object.SetActive(true);
        yield return new WaitForSeconds(2f);
        background_Object.GetComponent<Image>().DOFade(1, 1.5f).OnComplete(() =>
        {
            SceneManager.LoadScene(3);
        });

        yield return null;
    }

}