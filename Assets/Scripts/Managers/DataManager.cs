using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] SpiningWheelData _miniGameMachine;
    [SerializeField] SlotMachineData _slotMachineData;
    [SerializeField] WorldData _worldData;
    public PlayerData[] _playerData;
    private int symbolIndex = 0;
    private int counter = 0;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        Screen.fullScreen = true;

        ResetWorldData();
        _playerData[0].bet = 1;
        _playerData[0].hearts = 0;
        //ResetPlayerGameData();

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            ResetMiniGameMachineOddsData();
        }

        if (SceneManager.GetActiveScene().buildIndex == 2) {
            ResetslotMachineOddsData();
        }

        if (SceneManager.GetActiveScene().buildIndex == 3) {
            ResetMiniGameData();
        }
       
    }

    private void ResetslotMachineOddsData()
    {
        for (int i = 0; i < _slotMachineData.slot1.Length; i++)
        {
            //Debug.Log("Iteration: " + i);

            if (counter <= _slotMachineData.odds[symbolIndex])
            {
                counter++;
            }

            if (counter == _slotMachineData.odds[symbolIndex])
            {
                counter = 0;
                // Debug.Log("Counter: " + counter);

                if (symbolIndex < 4) { symbolIndex++; }

                //  Debug.Log("SymbolI: " + symbolIndex);
            }

            switch (symbolIndex)
            {
                case 0:
                    FillSlotMachineOddsData(i, counter);
                    break;

                case 1:
                    FillSlotMachineOddsData(i, counter);
                    break;

                case 2:
                    FillSlotMachineOddsData(i, counter);
                    break;

                case 3:
                    FillSlotMachineOddsData(i, counter);
                    break;

                case 4:
                    FillSlotMachineOddsData(i, counter);
                    break;
            }
        }
    }

    private void FillSlotMachineOddsData(int i, int counter)
    {
        _slotMachineData.slot1[i] = symbolIndex;
        _slotMachineData.slot2[i] = symbolIndex;
        _slotMachineData.slot3[i] = symbolIndex;
    }


    private void ResetMiniGameMachineOddsData()
    {
        for (int i = 0; i < _miniGameMachine.wheelsSlots.Length; i++)
        {
            //Debug.Log("Iteration: " + i);

            if (counter <= _miniGameMachine.odds[symbolIndex])
            {
                counter++;
            }

            if (counter == _miniGameMachine.odds[symbolIndex])
            {
                counter = 0;
                // Debug.Log("Counter: " + counter);

                if (symbolIndex < 4) { symbolIndex++; }

                //  Debug.Log("SymbolI: " + symbolIndex);
            }

            switch (symbolIndex)
            {
                case 0:
                    FillMiniGameMachineOddsData(i, counter);
                    break;

                case 1:
                    FillMiniGameMachineOddsData(i, counter);
                    break;

                case 2:
                    FillMiniGameMachineOddsData(i, counter);
                    break;

                case 3:
                    FillMiniGameMachineOddsData(i, counter);
                    break;

                case 4:
                    FillMiniGameMachineOddsData(i, counter);
                    break;
            }
        }
    }

    private void FillMiniGameMachineOddsData(int i, int counter)
    {
        _miniGameMachine.wheelsSlots[i] = symbolIndex;
    }


    private void ResetWorldData()
    {
        _worldData.buldingModeIsOn = false;

        _worldData.priceToBuild[0] = _worldData.house_1_Price;
        _worldData.priceToBuild[1] = _worldData.house_2_Price;
        _worldData.priceToBuild[2] = _worldData.house_3_Price;
        _worldData.priceToBuild[3] = _worldData.house_4_Price;
        _worldData.priceToBuild[4] = _worldData.house_5_Price;

        // for (int i = 0; i < _worldData.isBuilded.Length; i++)
        // {
        //     _worldData.isBuilded[i] = false;
        // }

    }

    private void ResetPlayerGameData()
    {
        for (int i = 0; i < _playerData.Length; i++)
        {
            _playerData[i].coins = 0;
            _playerData[i].spins = 50;
            _playerData[i].moreSpinsTimer = 60f;
            _playerData[i].bet = 1;
            _playerData[i].hearts = 0;
            _playerData[i].playerProgress = 0;
            _playerData[i].score = 0;
            _playerData[i].crowns = 0;
            _playerData[i].miniGameTicket = 0;
        }
    }

    private void ResetMiniGameData()
    {
        _miniGameData.gameIsOver = false;

        for (int i = 0; i < _playerData.Length; i++)
        {
            _playerData[i].hearts = 3;
            _playerData[i].score = 0;
        }
    }
}
