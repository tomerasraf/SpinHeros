using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenScreenTransition : MonoBehaviour
{
    [SerializeField] Image background_Image;
    private void Start()
    {
        background_Image.DOColor(Color.black, 0f).OnComplete(() =>
        {
            background_Image.DOFade(0, 2f).OnComplete(() =>
            {
                background_Image.enabled = false;
            });
        });
    }

    public void WorldSceneTransition()
    {
        background_Image.enabled = true;
        background_Image.DOFade(1, 2f).OnComplete(() =>
        {
            SceneManager.LoadScene(2);
        });
    }

}