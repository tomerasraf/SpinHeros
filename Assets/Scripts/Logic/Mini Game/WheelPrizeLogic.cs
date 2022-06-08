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
   


    public void CheckWheelResult()
    {
        switch (_spiningWheelData.results[0])
        {
            case 1:
                ChooseCharacter.Raise();
                break;
        }

        CheckPrize(0);

    }

    public void CheckPrize(int id)
    {
        switch (_spiningWheelData.results[id])
        {

            case 0:
                _playersData[id].score += _spiningWheelData.fishPrize;
                _playersData[id].currentPrize = _spiningWheelData.fishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();

                break;

            case 2:
                _playersData[id].score += _spiningWheelData.shoePrize;
                _playersData[id].currentPrize = _spiningWheelData.shoePrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();
                break;

            case 3:
                _playersData[id].score += _spiningWheelData.legnderyFishPrize;
                _playersData[id].currentPrize = _spiningWheelData.legnderyFishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();

                break;

            case 4:
                _playersData[id].score += _spiningWheelData.rareFishPrize;
                _playersData[id].currentPrize = _spiningWheelData.rareFishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();
                break;
        }
    }
}
