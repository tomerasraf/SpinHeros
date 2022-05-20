using UnityEngine;
using DG.Tweening;
using TMPro;

public class CollectScreenUI : MonoBehaviour
{
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
        collectScreen_UI.transform.DOScale(1, 1);

        coinPrize_Text.text = "Coin Prize: 40,000";
        spinPrize_Text.text = "Spin Prize: 10";
        bonusPrize_Text.text = "Bonus Prize: 10,000";
    }

}