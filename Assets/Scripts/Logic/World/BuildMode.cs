using System;
using UnityEngine;
using System.Collections;

public class BuildMode : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] GameSettingsData _gameSettingsData;
    [SerializeField] PlayerData _playerData;
    [SerializeField] WorldData _worldData;

    [Header("Building UI Min & Max move limit")]
    [SerializeField] float minLimitedValue;
    [SerializeField] float maxLimitedValue;

    [Header("Slider Object")]
    [SerializeField] GameObject buildingsUI_Slider;

    [Header("Slide Sensitivity")]
    [SerializeField] float slideSensitivity;
    [SerializeField] float smoothSpeed;

    [Header("Buildings Gameobjects")]
    [SerializeField] GameObject[] buildingGameobjects;

    [Header("Events")]
    [SerializeField] VoidEvent playerSpentCoins;
    [SerializeField] IntEvent notEnoughCoins;
    [SerializeField] IntEvent rewardAnimation;
    [SerializeField] VoidEvent miniGameUI_Updater;

    [Header("Triggers")]
    [SerializeField] GameObject exitBuildModeButton;


    private Vector3 endTouchPosition;

    private void Start()
    {
        LoadBuildingsData();
    }

    public void BuildingModeIsOn()
    {
        _worldData.buldingModeIsOn = true;
        exitBuildModeButton.SetActive(true);
    }

    public void BuildingModeIsOff()
    {
        _worldData.buldingModeIsOn = false;
        exitBuildModeButton.SetActive(false);
    }

    public void BuildListener(int id)
    {
        BuilderPriceCheck(id);
    }

    private void Update()
    {
        if (!_worldData.buldingModeIsOn || _gameSettingsData.buildControlsOff) { return; }
        UI_TouchMovement();
    }

    private void BuilderPriceCheck(int buttonID)
    {
        if (_playerData.coins >= _worldData.priceToBuild[buttonID])
        {
            _playerData.coins -= _worldData.priceToBuild[buttonID];
            _playerData.crowns++;
            playerSpentCoins.Raise();
            Build(buttonID);
        }
        else
        {
            notEnoughCoins.Raise(buttonID);
        }
    }

    private void Build(int buttonID)
    {
        buildingGameobjects[buttonID].SetActive(true);
        _worldData.isBuilded[buttonID] = true;

        buildReward(buttonID);
    }

    private void buildReward(int id) {
        _playerData.spins += _worldData.spinReward[id];
        _playerData.miniGameTicket += _worldData.miniGameTicketsReward[id];

        if (id == 0) { return; }
        rewardAnimation.Raise(id);
        miniGameUI_Updater.Raise();
    }

    private void UI_TouchMovement()
    {
        endTouchPosition = TouchInput.DetectTouchInput(minLimitedValue, maxLimitedValue);

        Vector3 smoothedPosition = Vector3.Lerp(buildingsUI_Slider.transform.position, endTouchPosition, smoothSpeed);
        Vector3 newUIPosition = new Vector3(-smoothedPosition.x * slideSensitivity * Time.fixedDeltaTime, buildingsUI_Slider.transform.position.y, buildingsUI_Slider.transform.position.z);

        buildingsUI_Slider.transform.position = newUIPosition;
    }

    private void LoadBuildingsData()
    {
        for (int i = 0; i < _worldData.isBuilded.Length; i++)
        {
            if (_worldData.isBuilded[i])
            {
                buildingGameobjects[i].SetActive(true);
            }
        }
    }

}
