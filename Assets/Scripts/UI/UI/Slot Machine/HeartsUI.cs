using DG.Tweening;
using UnityEngine;

public class HeartsUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] GameSettingsData _gameSettingsData;
    [SerializeField] private PlayerData _playerData;

    [Header("Images")]
    [SerializeField] private GameObject[] heartImages;

    private void Start()
    {
        DisplayHeartUI_Start();
    }

    private void DisplayHeartUI_Start()
    {
        if (_playerData.hearts == 0)
        {
            for (int i = 0; i < heartImages.Length; i++)
            {
                heartImages[i].SetActive(false);
            }
        }

        if (_playerData.hearts == 1) {
            heartImages[0].SetActive(true);
        }

        if (_playerData.hearts == 2) {
            heartImages[0].SetActive(true);
            heartImages[1].SetActive(true);
        }

        if (_playerData.hearts == 3) {
            heartImages[0].SetActive(true);
            heartImages[1].SetActive(true);
            heartImages[2].SetActive(true);
        }

    }

    public void HeartUI_Updater()
    {
        if (_playerData.hearts <= 0) { return; }

        heartImages[_playerData.hearts - 1].transform.DOScale(0, 0);
        heartImages[_playerData.hearts - 1].SetActive(true);
        heartImages[_playerData.hearts - 1].transform.DOScale(0.8f, 0.3f).SetEase(Ease.OutBounce);

    }

    public void DecreaseHeartUI_Animation() {
        if (_playerData.hearts < 0) { return; }

        heartImages[_playerData.hearts].transform.DOScale(0, 0.5f).SetEase(Ease.OutBounce).OnComplete(() => {
            heartImages[_playerData.hearts].SetActive(false);
        });
       
    }

}