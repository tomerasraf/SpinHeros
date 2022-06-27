using DG.Tweening;
using TMPro;
using UnityEngine;

public class MiniGameTicketUI : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameObject miniGameButton;
    [SerializeField] TextMeshProUGUI miniGameTicketText;
    [SerializeField] GameObject notEnoughHeartMassage;

    private Vector3 notEnoughMassageStartPos;
    private void Start()
    {
        notEnoughMassageStartPos = notEnoughHeartMassage.transform.position;
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

    public void NotEnoughHearts_Listener() {

        notEnoughHeartMassage.transform.DOMove(notEnoughMassageStartPos, 0);
        notEnoughHeartMassage.GetComponent<TextMeshProUGUI>().DOFade(0, 0).OnComplete(() =>
        {
            notEnoughHeartMassage.SetActive(true);
            notEnoughHeartMassage.transform.DOMoveY(notEnoughHeartMassage.transform.position.y + 100, 2f);
            notEnoughHeartMassage.GetComponent<TextMeshProUGUI>().DOFade(1, 2f).OnComplete(() => {
                notEnoughHeartMassage.GetComponent<TextMeshProUGUI>().DOFade(0, 0.3f);
                   
            });
        });
    }
}