using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] TextMeshProUGUI scoreUI;

    public void ScoreUI_Updater()
    {
        scoreUI.text = _playerData.score.ToString();
    }
}