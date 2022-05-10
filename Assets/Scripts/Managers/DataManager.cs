using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] WorldData _worldData;
    public PlayerData[] _playerData;

    private void Awake()
    {
        ResetWorldData();
        ResetMiniGameData();
    }

    private void ResetWorldData()
    {
        _worldData.priceToBuild[0] = _worldData.house_1_Price;
        _worldData.priceToBuild[1] = _worldData.house_2_Price;
        _worldData.priceToBuild[2] = _worldData.house_3_Price;
        _worldData.priceToBuild[3] = _worldData.house_4_Price;
        _worldData.priceToBuild[4] = _worldData.house_5_Price;

        for (int i = 0; i < _worldData.isBuilded.Length; i++)
        {
            _worldData.isBuilded[i] = false;
        }

    }

    private void ResetMiniGameData()
    {
        for (int i = 0; i < _playerData.Length; i++)
        {
            _playerData[i].hearts = 3;
            _playerData[i].playerPlace = 4;
            _playerData[i].playerProgress = 0;
            _playerData[i].score = 0;
            _playerData[i].crowns = 0;
        }
    }
}
