using UnityEngine;
using TMPro;

public class MiniGameTicketUI : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] TextMeshProUGUI miniGameTicketText;

    public void miniGameTicketUI_Updater()
    {
        miniGameTicketText.text = _playerData.miniGameTicket.ToString();
    }
}