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
            
            case 0  :
                _playersData[id].score += _spiningWheelData.fishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();

                break;

            case 2:
                _playersData[id].score += _spiningWheelData.shoePrize;
                Score_Update.Raise();
                break;

            case 3:
                _playersData[id].score += _spiningWheelData.legnderyFishPrize;

                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();

                break;
      
            case 4:
                _playersData[id].score += _spiningWheelData.rareFishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();
                break;
        }
    } 
}
