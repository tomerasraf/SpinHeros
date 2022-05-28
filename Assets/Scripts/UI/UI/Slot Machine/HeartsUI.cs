using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerData _playerData;

    [Header("Images")]
    [SerializeField] private GameObject[] heartImages;

    private void Start()
    {
        HeartUI_Updater();
    }

    public void HeartUI_Updater()
    {
        switch (_playerData.hearts)
        {
            case 0:
                heartImages[0].SetActive(false);
                heartImages[1].SetActive(false);
                heartImages[2].SetActive(false);
                break;

            case 1:
                heartImages[0].SetActive(true);
                heartImages[1].SetActive(false);
                heartImages[2].SetActive(false);
                break;
            case 2:
                heartImages[0].SetActive(true);
                heartImages[1].SetActive(true);
                heartImages[2].SetActive(false);
                break;
            case 3:
                heartImages[0].SetActive(true);
                heartImages[1].SetActive(true);
                heartImages[2].SetActive(true);
                break;
        }
    }
}