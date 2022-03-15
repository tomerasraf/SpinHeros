using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] PlayerData _playerData;

    public void CoinUI_Updater()
    {
        coinText.text = _playerData.coins.ToString();
    }
}