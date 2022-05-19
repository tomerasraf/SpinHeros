using UnityEngine;
using TMPro;

public class MiniGameTicketUI : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] TextMeshProUGUI miniGameTicketText;

    private void Start()
    {
        miniGameTicketUI_Updater();
    }

    public void miniGameTicketUI_Updater()
    {
        miniGameTicketText.text = _playerData.miniGameTicket.ToString();
    }
}