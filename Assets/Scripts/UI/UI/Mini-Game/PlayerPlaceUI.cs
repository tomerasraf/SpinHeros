using UnityEngine;
using TMPro;

public class PlayerPlaceUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] placesText;
    [SerializeField] PlayerData[] _playerData;

    private void Start()
    {
        PlaceUI_Updater();
    }

    public void PlaceUI_Updater()
    {
        for (int i = 0; i < placesText.Length; i++)
        {
            placesText[i].text = "#" + _playerData[i].playerPlace.ToString();
        }
    }


}