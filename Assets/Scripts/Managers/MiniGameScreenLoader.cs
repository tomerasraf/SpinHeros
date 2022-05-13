using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class MiniGameScreenLoader : MonoBehaviour
{
    [SerializeField] GameObject Background_Image;

    IEnumerator Start()
    {
        Background_Image.SetActive(true);
        Background_Image.GetComponent<Image>().DOFade(0, 1.5f).OnComplete(() =>
        {
            Background_Image.SetActive(false);
        });

        yield return null;
    }

}