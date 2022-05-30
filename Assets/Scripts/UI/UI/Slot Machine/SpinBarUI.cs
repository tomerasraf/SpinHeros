using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinBarUI : MonoBehaviour
{
    [SerializeField] GameObject spinBar_Object;
    [SerializeField] Image spinBarImage;
    [SerializeField] PlayerData _playerData;
    [SerializeField] TextMeshProUGUI spinsText;

    private void Start()
    {
        SpinBarText_Updater();
    }

    public void SpinBarText_Updater()
    {

        if (_playerData.spins > 0)
        {
            spinsText.text = $"{_playerData.spins}/{_playerData.maxSpins}";
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

    public void SpinBarUIAnimation_Updater()
    {
        spinBar_Object.transform.DOScale(0.035f, 0.1f).OnComplete(() =>
        {
            spinBar_Object.transform.DOScale(0.026f, 0.1f).OnComplete(() =>
            {

                if (_playerData.spins > 0)
                {
                    spinsText.text = $"{_playerData.spins}/{_playerData.maxSpins}";
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

            });
        });
    }
}