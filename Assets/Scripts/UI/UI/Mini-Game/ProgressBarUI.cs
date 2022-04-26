using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] PlayerData[] _playersData;
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] Image[] progressBars;

    private void Start()
    {
        ProgressBarUI_Updater();
    }

    public void ProgressBarUI_Updater()
    {
        for (int i = 0; i < _playersData.Length; i++)
        {
            progressBars[i].fillAmount = (float)_playersData[i].score / _miniGameData.playersGoal;
        }
    }
}