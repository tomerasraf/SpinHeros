using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

public class CoinPopupUI : MonoBehaviour
{
    [SerializeField] SlotMachineData _slotMachineData;
    [SerializeField] GameObject coinPrizePopup;

    private Vector3 popupTextStartPosition;

    private void Start()
    {
        popupTextStartPosition = coinPrizePopup.transform.position;
    }

    public void PopupPrizeText_Listener()
    {
        StartCoroutine(Popup_Coroutine());
    }

    IEnumerator Popup_Coroutine()
    {
        coinPrizePopup.GetComponent<TextMeshProUGUI>().text = "+" + _slotMachineData.CurrentPrize.ToString();
        coinPrizePopup.GetComponent<TextMeshProUGUI>().DOFade(1, 0);
        coinPrizePopup.transform.DOMoveY(popupTextStartPosition.y - 400, 0f);
        coinPrizePopup.GetComponent<TextMeshProUGUI>().enabled = true;
        coinPrizePopup.transform.DOMoveY(popupTextStartPosition.y, 2f);
        coinPrizePopup.GetComponent<TextMeshProUGUI>().DOFade(0, 2.2f);

        yield return new WaitForSeconds(2.2f);
        coinPrizePopup.GetComponent<TextMeshProUGUI>().enabled = false;

        yield return null;
    }
}