using UnityEngine;
using TMPro;

public class CrownUI : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] TextMeshProUGUI corwnsScoreText;

    private void Start()
    {
        crown_UI_Updater();
    }

    public void crown_UI_Updater()
    {
        corwnsScoreText.text = _playerData.crowns.ToString();
    }
}