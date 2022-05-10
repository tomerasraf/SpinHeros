using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildMode : MonoBehaviour
{
    [Header("Data")]
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

    [Header("Triggers")]
    [SerializeField] GameObject exitBuildModeButton;

    private Vector3 endTouchPosition;

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
        if (!_worldData.buldingModeIsOn) { return; }
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
            Debug.Log("You are poor as fuck");
        }
    }

    private void Build(int buttonID)
    {
        buildingGameobjects[buttonID].SetActive(true);
        _worldData.isBuilded[buttonID] = true;

    }

    private void UI_TouchMovement()
    {
        endTouchPosition = TouchInput.DetectTouchInput(minLimitedValue, maxLimitedValue);

        Vector3 smoothedPosition = Vector3.Lerp(buildingsUI_Slider.transform.position, endTouchPosition, smoothSpeed);
        Vector3 newUIPosition = new Vector3(-smoothedPosition.x * slideSensitivity * Time.fixedDeltaTime, buildingsUI_Slider.transform.position.y, buildingsUI_Slider.transform.position.z);

        buildingsUI_Slider.transform.position = newUIPosition;
    }



}
