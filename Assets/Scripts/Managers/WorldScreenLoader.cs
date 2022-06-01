using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WorldScreenLoader : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
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
        if (_playerData.miniGameTicket > 0) {
            StartCoroutine(SceneTransitionToMiniGame_Coroutine());
        }
        else
        {
            return;
        }
        
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