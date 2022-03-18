using UnityEngine;
using TMPro;

public class ExtraSpinsUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private TextMeshProUGUI extraSpinsText;

    public void ExtraSpinsUI_Updater()
    {
        if (_playerData.spins >= _playerData.maxSpins)
        {
            extraSpinsText.text = $"+{_playerData.extraSpins} Extra";
        }
    }

    private void Update()
    {
        if(_playerData.spins < _playerData.maxSpins)
        extraSpinsText.text = $"5 more in {(int)_playerData.moreSpinsTimer}";
    }
}