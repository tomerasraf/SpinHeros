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
        spinBarImage.fillAmount = (float)_playerData.spins / _playerData.maxSpins;

        spinsText.text = $"{_playerData.spins}/{_playerData.maxSpins}";
    }
}