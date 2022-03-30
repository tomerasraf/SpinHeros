using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPrizeLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;
    [SerializeField] PlayerData[] _playerData;

    [Header("Events")]
    [SerializeField] VoidEvent ChooseCharacter;


    public void CheckWheelResult()
    {
        switch (_spiningWheelData.results[0])
        {
            case 0:
                ChooseCharacter.Raise();
                break;
            case 1:
                ChooseCharacter.Raise();
                break;
            case 2:
                ChooseCharacter.Raise();
                break;
            case 6:
                ChooseCharacter.Raise();
                break;
        }

        for (int i = 0; i < _spiningWheelData.results.Length; i++)
        {
            switch (_spiningWheelData.results[i])
            {
                case 3:
                    _playerData[i].score += _spiningWheelData.legnderyFishPrize;
                    break;
                case 4:
                    _playerData[i].score += _spiningWheelData.fishPrize;
                    break;
                case 5:
                    _playerData[i].score += _spiningWheelData.shoePrize;
                    break;
                case 7:
                    _playerData[i].score += _spiningWheelData.rareFishPrize;
                    break;
            }
        }
    }
}
