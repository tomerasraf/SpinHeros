using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerData _playerData;

    [Header("Images")]
    [SerializeField] private Image[] heartImages;

    public void HeartUI_Updater()
    {
        switch (_playerData.hearts)
        {
            case 0:
                heartImages[0].enabled = false;
                heartImages[1].enabled = false;
                heartImages[2].enabled = false;
                break;

            case 1:
                heartImages[0].enabled = true;
                heartImages[1].enabled = false;
                heartImages[2].enabled = false;
                break;
            case 2:
                heartImages[0].enabled = true;
                heartImages[1].enabled = true;
                heartImages[2].enabled = false;
                break;
            case 3:
                heartImages[0].enabled = true;
                heartImages[1].enabled = true;
                heartImages[2].enabled = true;
                break;
        }
    }
}