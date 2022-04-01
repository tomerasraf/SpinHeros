using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPrizeLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;
    [SerializeField] PlayerData[] _playersData;

    [Header("Events")]
    [SerializeField] VoidEvent ChooseCharacter;


    public void CheckWheelResult()
    {
        switch (_spiningWheelData.results[0])
        {
            case 1:
                ChooseCharacter.Raise();
                break;
            case 6:
                KrakenAttack();
                break;
        }

        for (int i = 0; i < _spiningWheelData.results.Length; i++)
        {
            switch (_spiningWheelData.results[i])
            {
                case 0:
                    Replace(i);
                    break;
                case 2:
                    _playersData[i].score = _playersData[0].maxScore;
                    break;
                case 3:
                    _playersData[i].score += _spiningWheelData.legnderyFishPrize;
                    break;
                case 4:
                    _playersData[i].score += _spiningWheelData.fishPrize;
                    break;
                case 5:
                    _playersData[i].score += _spiningWheelData.shoePrize;
                    break;
                case 7:
                    _playersData[i].score += _spiningWheelData.rareFishPrize;
                    break;
            }
        }
    }
    public void KrakenAttack()
    {
        for (int i = 0; i < _playersData.Length; i++)
        {
            if (i != 0)
            {
                _playersData[i].hearts--;
            }
        }
    }

    public void Replace(int playerNum)
    {
        int rand = Random.Range(1, 4);
        int tempPlace = _playersData[playerNum].playerPlace;
        Debug.Log(tempPlace + "first");
        _playersData[playerNum].playerPlace = rand;
        for (int i = 0; i < _playersData.Length; i++)
        {
            if (_playersData[i].playerPlace == rand)
            {
                Debug.Log(_playersData[i].playerPlace + "second");
                _playersData[i].playerPlace = tempPlace;
            }
        }
    }
}
