using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectScreenUI : MonoBehaviour
{
    [SerializeField] GameObject collectScreen_UI;
    [SerializeField] TextMeshProUGUI coinPrize_Text;
    [SerializeField] TextMeshProUGUI spinPrize_Text;
    [SerializeField] TextMeshProUGUI bonusPrize_Text;

    public void DisplayCollectScreen_Listener()
    {
        collectScreen_UI.SetActive(true);
        coinPrize_Text.text = "Coin Prize: 40,000";
        spinPrize_Text.text = "Spin Prize: 10";
        bonusPrize_Text.text = "Bonus Prize: 10,000";
    }

}