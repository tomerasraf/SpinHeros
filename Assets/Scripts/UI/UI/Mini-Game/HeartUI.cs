using UnityEngine;
using TMPro;

public class HeartUI : MonoBehaviour
{
    [SerializeField] PlayerData[] _playersData;
    [SerializeField] TextMeshProUGUI[] heartsTexts;

    private void Start()
    {
        HeartUI_Updater();
    }

    public void HeartUI_Updater()
    {
        for (int i = 0; i < heartsTexts.Length; i++)
        {
            heartsTexts[i].text = "X" + _playersData[i].hearts.ToString();
        }
    }
}