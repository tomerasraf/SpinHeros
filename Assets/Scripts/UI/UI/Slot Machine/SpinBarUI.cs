using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpinBarUI : MonoBehaviour
{
    [SerializeField] Image spinBarImage;
    [SerializeField] PlayerData _playerData;
    [SerializeField] TextMeshProUGUI spinsText;

    public void SpinBarUI_Updater()
    {
        if (_playerData.spins > 0)
        {
            spinsText.text = $"{_playerData.spins - 1}/{_playerData.maxSpins}";
        }
        else
        {
            spinsText.text = $"0/{_playerData.maxSpins}";
        }

        if (_playerData.spins >= _playerData.maxSpins)
        {
            spinsText.text = $"50/{_playerData.maxSpins}";
        }


        spinBarImage.fillAmount = (float)_playerData.spins / _playerData.maxSpins;
    }
}