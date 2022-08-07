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
    [SerializeField] SlotMachineData _slotMachineData;

    [Header("Background")]
    [SerializeField] GameObject background_Object;

    [Header("Events")]
    [SerializeField] VoidEvent flyAndAvoidIntro;

    private static int randomMiniGameIndex;
    private static int previewsMiniGameIndex;
    private int maxAttempts = 10;

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
        /*   // Make sure that the first mini-game is the fishing mini game.
           if (_gameSettingsData.tutorialMode) {
               randomMiniGameIndex = 4;
               StartCoroutine(SceneTransitionToMiniGame_Coroutine(randomMiniGameIndex));
               previewsMiniGameIndex = randomMiniGameIndex;
               return;
           }

           // Make sure that the same mini-game does not repeat
           for (int i = 0;  randomMiniGameIndex == previewsMiniGameIndex && i < maxAttempts; i++) { 
               randomMiniGameIndex = Random.Range(3, 5);
           }

           previewsMiniGameIndex = randomMiniGameIndex;*/

        randomMiniGameIndex = 4;
        _slotMachineData.currentMiniGame = randomMiniGameIndex;
        flyAndAvoidIntro.Raise();
    }

    public void LoadMiniGame_Listener(int miniGameIndex) {
        StartCoroutine(SceneTransitionToMiniGame_Coroutine(miniGameIndex));
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