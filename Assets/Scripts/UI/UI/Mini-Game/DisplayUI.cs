using DG.Tweening;
using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    [SerializeField] GameObject wheel;
    [SerializeField] GameObject spinButton;
    [SerializeField] GameObject playersInfo_1;
    [SerializeField] GameObject playersInfo_2;
    [SerializeField] GameObject playersInfo_3;
    [SerializeField] GameObject playersInfo_4;


    private Vector3 startPlayerInfo_1Position;
    private Vector3 startPlayerInfo_2Position;
    private Vector3 startPlayerInfo_3Position;
    private Vector3 startPlayerInfo_4Position;

    private Vector3 startWheelPosition;
    private Vector3 startFooterPosition;
    private Vector3 startSpinButtonPosition;
    private float offsetUI = 1500;

    private void Start()
    {
        InitializeUIStartPositions();
    }

    private void InitializeUIStartPositions()
    {
        startPlayerInfo_1Position = playersInfo_1.transform.position;
        startPlayerInfo_2Position = playersInfo_2.transform.position;
        startPlayerInfo_3Position = playersInfo_3.transform.position;
        startPlayerInfo_4Position = playersInfo_4.transform.position;

        startWheelPosition = wheel.transform.position;

        startSpinButtonPosition = spinButton.transform.position;

        playersInfo_1.transform.DOMoveY(startPlayerInfo_1Position.y + offsetUI, 0);
        playersInfo_2.transform.DOMoveY(startPlayerInfo_2Position.y + offsetUI, 0);
        playersInfo_3.transform.DOMoveY(startPlayerInfo_3Position.y + offsetUI, 0);
        playersInfo_4.transform.DOMoveY(startPlayerInfo_4Position.y + offsetUI, 0);

        wheel.transform.DOMoveY(startWheelPosition.y - 100, 0);
        spinButton.transform.DOMoveY(startSpinButtonPosition.y - offsetUI, 0);
    }

    public void DisplayUI_On()
    {
        UIStartAnimation();
    }

    public void DisplayUI_Off()
    {
        playersInfo_1.transform.DOMoveY(startPlayerInfo_1Position.y + offsetUI, 2);
        playersInfo_2.transform.DOMoveY(startPlayerInfo_2Position.y + offsetUI, 2);
        playersInfo_3.transform.DOMoveY(startPlayerInfo_3Position.y + offsetUI, 2);
        playersInfo_4.transform.DOMoveY(startPlayerInfo_4Position.y + offsetUI, 2);

        spinButton.transform.DOMoveY(startSpinButtonPosition.y - offsetUI, 2);

    }

    private void UIStartAnimation()
    {
        playersInfo_1.transform.DOMoveY(startPlayerInfo_1Position.y, 0.4f);
        playersInfo_2.transform.DOMoveY(startPlayerInfo_2Position.y, 0.4f);
        playersInfo_3.transform.DOMoveY(startPlayerInfo_3Position.y, 0.4f);
        playersInfo_4.transform.DOMoveY(startPlayerInfo_4Position.y, 0.4f);

        wheel.transform.DOMoveY(startWheelPosition.y, 1);
        spinButton.transform.DOMoveY(startSpinButtonPosition.y, 0.4f);
    }


}