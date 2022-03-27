using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPrizeLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;
    [SerializeField] PlayerData _playerData;

    [Header("Events")]
    [SerializeField] private VoidEvent shark;
    [SerializeField] private VoidEvent kraken;
    [SerializeField] private VoidEvent anchor;
    [SerializeField] private VoidEvent replace;


    public void CheckWheelResult()
    {
        switch (_spiningWheelData.result)
        {
            case 0:
                replace.Raise();
                break;
            case 1:
                shark.Raise();
                break;
            case 2:
                anchor.Raise();
                break;
            case 3:
                _playerData.score += _spiningWheelData.legnderyFishPrize;
                break;
            case 4:
                _playerData.score += _spiningWheelData.fishPrize;
                break;
            case 5:
                _playerData.score += _spiningWheelData.shoePrize;
                break;
            case 6:
                kraken.Raise();
                break;
            case 7:
                _playerData.score += _spiningWheelData.rareFishPrize;
                break;
        }
    }
}
