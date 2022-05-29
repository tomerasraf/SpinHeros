using DG.Tweening;
using TMPro;
using UnityEngine;

public class MiniGameTicketUI : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameObject miniGameButton;
    [SerializeField] TextMeshProUGUI miniGameTicketText;

    private void Start()
    {
        miniGameTicketText.text = _playerData.miniGameTicket.ToString();
    }

    public void miniGameButtonAnimation_Listener()
    {
        miniGameButton.transform.DOScale(1, 0.1f).OnComplete(() =>
        {
            miniGameButton.transform.DOScale(0.8f, 0.1f);
            miniGameTicketText.text = _playerData.miniGameTicket.ToString();
        });
    }
}