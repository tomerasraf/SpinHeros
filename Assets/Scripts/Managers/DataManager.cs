using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlayerData[] _playerData;

    private void Start()
    {
        for (int i = 0; i < _playerData.Length; i++)
        {
            _playerData[i].hearts = 3;
            _playerData[i].playerPlace = 4;
            _playerData[i].playerProgress = 0;
            _playerData[i].score = 0;
        }

    }
}
