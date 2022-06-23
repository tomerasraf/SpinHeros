using UnityEngine;
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


    private void Start()
    {
        collectScreen_UI.transform.DOScale(0, 0);
    }

    public void DisplayCollectScreen_Listener()
    {
        collectScreen_UI.SetActive(true);
        collectScreen_UI.transform.DOScale(1, 1).OnComplete(() => {

            coinPrize_Text.text = $"Coin Prize: {_miniGameData.winnerPrize}";
            spinPrize_Text.text = $"Spin Prize: {_miniGameData.winnerSpinPrize}";
            bonusPrize_Text.text = $"With Bonus: {(_playerData.amountPlayersAttacked * _miniGameData.attackBonus) + _miniGameData.winnerPrize}";
        });
    }



}