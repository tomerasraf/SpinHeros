using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

public class CollectScreenUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] PlayerData _playerData;

    [Header("UI")]
    [SerializeField] GameObject collectScreen_UI;
    [SerializeField] TextMeshProUGUI coinPrize_Text;
    [SerializeField] TextMeshProUGUI spinPrize_Text;
    [SerializeField] TextMeshProUGUI bonusPrize_Text;
    [SerializeField] TextMeshProUGUI overAllPrize_Text;
    
    private void Start()
    {
        collectScreen_UI.transform.DOScale(0, 0);
    }

    public void DisplayCollectScreenWinner_Listener()
    {
        StartCoroutine(DelayTimerWinnerScreen());
    }

    IEnumerator DelayTimerWinnerScreen() {

        yield return new WaitForSeconds(5);

        collectScreen_UI.SetActive(true);
        collectScreen_UI.transform.DOScale(1, 1).OnComplete(() => {

            coinPrize_Text.text = _miniGameData.winnerPrize.ToString("n0");
            spinPrize_Text.text = _miniGameData.winnerSpinPrize.ToString("n0");

            int bonus = _playerData.amountPlayersAttacked * _miniGameData.attackBonus;

            bonusPrize_Text.text = bonus.ToString("n0");

            int overAllPrize = (_playerData.amountPlayersAttacked * _miniGameData.attackBonus) + _miniGameData.winnerPrize;

            overAllPrize_Text.text = overAllPrize.ToString("n0");

        });

        yield return null;
    }

    public void DisplayCollectScreenLoser_Listener()
    {
        StartCoroutine(DelayDefeatScreen());
    }

    IEnumerator DelayDefeatScreen() {

        yield return new WaitForSeconds(5);

        collectScreen_UI.SetActive(true);
        collectScreen_UI.transform.DOScale(1, 1).OnComplete(() =>
        {

            coinPrize_Text.text = _miniGameData.loserPrize.ToString("n0");
            spinPrize_Text.text = _miniGameData.loserSpinPrize.ToString("n0");

            int bonus = _playerData.amountPlayersAttacked * _miniGameData.attackBonus;

            bonusPrize_Text.text = bonus.ToString("n0");

            int overAllPrize = (_playerData.amountPlayersAttacked * _miniGameData.attackBonus) + _miniGameData.loserPrize;

            overAllPrize_Text.text = overAllPrize.ToString("n0");

        });

        yield return null;
    }
}