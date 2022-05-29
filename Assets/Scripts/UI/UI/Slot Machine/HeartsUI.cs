using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HeartsUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerData _playerData;

    [Header("Images")]
    [SerializeField] private GameObject[] heartImages;

    private void Start()
    {
       // HeartUI_Updater();
    }

    public void HeartUI_Updater()
    {
        if (_playerData.hearts <= 0) { return; }

        heartImages[_playerData.hearts - 1].transform.DOScale(0, 0);
        heartImages[_playerData.hearts - 1].SetActive(true);
        heartImages[_playerData.hearts - 1].transform.DOScale(0.8f, 0.3f).SetEase(Ease.OutBounce);

    }
}