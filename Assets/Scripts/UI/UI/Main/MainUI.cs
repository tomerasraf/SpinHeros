using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] GameObject miniGameButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject coinPopupText;
    [SerializeField] GameObject betButton;
  
    private void Start()
    {
        if (!_gameSettingsData.tutorialMode) {
            canvas.SetActive(true);
            spinButton.SetActive(true);
            coinBar.SetActive(true);
            hearts.SetActive(true);
            rating.SetActive(true);
            buildModeButton.SetActive(true);
            miniGameButton.SetActive(true);
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
}
