using UnityEngine;
using TMPro;

public class BetUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI betText;
    [SerializeField] PlayerData _playerData;

    public void BetUI_Updater()
    {
        if (_playerData.bet == 1)
        {
            _playerData.bet = 2;
            betText.text = $"X{_playerData.bet}";
        }
        else if (_playerData.bet == 2)
        {
            _playerData.bet = 3;
            betText.text = $"X{_playerData.bet}";
        }
        else
        {
            _playerData.bet = 1;
            betText.text = $"X{_playerData.bet}";
        }
    }
}