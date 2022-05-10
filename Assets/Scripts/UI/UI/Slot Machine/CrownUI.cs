using UnityEngine;
using TMPro;

public class CrownUI : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] TextMeshProUGUI corwnsScoreText;

    public void crown_UI_Updater()
    {
        corwnsScoreText.text = _playerData.crowns.ToString();
    }
}