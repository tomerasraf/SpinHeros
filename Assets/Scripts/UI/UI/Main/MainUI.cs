using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] GameSettingsData _gameSettingsData;

    [Header("UI")]
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject spinButton;
    [SerializeField] GameObject coinBar;
    [SerializeField] GameObject hearts;
    [SerializeField] GameObject rating;
    [SerializeField] GameObject buildModeButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject coinPopupText;
    [SerializeField] GameObject betButton;

    [Header("UI Zones")]
    [SerializeField] GameObject aboveCenterScreenUI;
    [SerializeField] GameObject belowCenterScreenUI;
  
    private void Start()
    {
        if (!_gameSettingsData.tutorialMode) {
            canvas.SetActive(true);
            spinButton.SetActive(true);
            coinBar.SetActive(true);
            hearts.SetActive(true);
            rating.SetActive(true);
            buildModeButton.SetActive(true);
            menuButton.SetActive(true);
            menuUI.SetActive(true);
            coinPopupText.SetActive(true);
            betButton.SetActive(true);
        }
        else
        {
            betButton.SetActive(false);
            coinPopupText.SetActive(true);
        }
    }

    public void TurnOffUI_Listener() {
        canvas.SetActive(false);
    }

    public void TurnOnUI_Listener() {
        canvas.SetActive(true);
    }

    public void UIPullbackAnimation() {
        aboveCenterScreenUI.transform.DOMoveY(aboveCenterScreenUI.transform.position.y + 1000, 1);
        belowCenterScreenUI.transform.DOMoveY(belowCenterScreenUI.transform.position.y - 1000, 1);
    }
}
