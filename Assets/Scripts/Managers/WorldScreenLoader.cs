using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WorldScreenLoader : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameSettingsData _gameSettingsData;

    [SerializeField] GameObject background_Object;

    private int previewsMiniGameIndex;

    private void Start()
    {
        background_Object.SetActive(true);
        background_Object.GetComponent<Image>().DOFade(1, 0);
        background_Object.GetComponent<Image>().DOFade(0, 1.5f).OnComplete(() =>
        {
            background_Object.SetActive(false);
        });

    }

    public void MiniGame_Listener()
    {
        // Make sure that the first mini game is the fishing mini game.
        if (_gameSettingsData.tutorialMode) {
            StartCoroutine(SceneTransitionToMiniGame_Coroutine(3));
            previewsMiniGameIndex = 3;
            return;
        }

        int randomMiniGameIndex = Random.Range(3, 5);

        previewsMiniGameIndex = randomMiniGameIndex;
        // Make sure that the same mini game does not repeat

        while (randomMiniGameIndex == previewsMiniGameIndex) { 
            randomMiniGameIndex = Random.Range(3, 5);
        }

        StartCoroutine(SceneTransitionToMiniGame_Coroutine(randomMiniGameIndex));

    }

    IEnumerator SceneTransitionToMiniGame_Coroutine(int levelIndex)
    {
        background_Object.SetActive(true);
        yield return new WaitForSeconds(2f);
        background_Object.GetComponent<Image>().DOFade(1, 1.5f).OnComplete(() =>
        {
            SceneManager.LoadScene(levelIndex);
        });

        yield return null;
    }

}