using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPrizeLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;
    [SerializeField] PlayerData[] _playersData;
    [SerializeField] MiniGameData _miniGameData;

    [Header("Events")]
    [SerializeField] VoidEvent ChooseCharacter;
    [SerializeField] VoidEvent Score_Update;
    [SerializeField] IntEvent PlayerID_Anim_FishPrize;
    [SerializeField] IntEvent CreateFish_Prefab;


    public void CheckWheelResult()
    {
        switch (_spiningWheelData.results[0])
        {
            case 1:
                ChooseCharacter.Raise();
                break;
            case 6:
                KrakenAttack();
                Score_Update.Raise();
                break;
        }

        for (int id = 0; id < _spiningWheelData.results.Length; id++)
        {
            CheckPrize(id);
        }
    }

    private void CheckPrize(int id)
    {
        switch (_spiningWheelData.results[id])
        {
            case 1:
                Replace(id);
                break;
            case 2:
                _playersData[id].score = _miniGameData.playersGoal;
                Score_Update.Raise();
                break;
            case 3:
                _playersData[id].score += _spiningWheelData.legnderyFishPrize;

                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();

                break;
            case 4:
                _playersData[id].score += _spiningWheelData.fishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();

                break;
            case 5:
                _playersData[id].score += _spiningWheelData.shoePrize;
                Score_Update.Raise();
                break;
            case 7:
                _playersData[id].score += _spiningWheelData.rareFishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();
                break;
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
        _playersData[playerNum].playerPlace = rand;
        for (int i = 0; i < _playersData.Length; i++)
        {
            if (_playersData[i].playerPlace == rand)
            {
                _playersData[i].playerPlace = tempPlace;
            }
        }
    }
}
