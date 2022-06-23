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
    [SerializeField] TextMeshProUGUI overAllPrize_Text;


    private void Start()
    {
        collectScreen_UI.transform.DOScale(0, 0);
    }

    public void DisplayCollectScreen_Listener()
    {
        collectScreen_UI.SetActive(true);
        collectScreen_UI.transform.DOScale(1, 1).OnComplete(() => {

            coinPrize_Text.text = _miniGameData.winnerPrize.ToString("n0");
            spinPrize_Text.text = _miniGameData.winnerSpinPrize.ToString("n0");

            int bonus =_playerData.amountPlayersAttacked * _miniGameData.attackBonus;

            bonusPrize_Text.text = bonus.ToString("n0");

            int overAllPrize = (_playerData.amountPlayersAttacked * _miniGameData.attackBonus) + _miniGameData.winnerPrize;

            overAllPrize_Text.text = overAllPrize.ToString("n0");
            
        });
    }



}