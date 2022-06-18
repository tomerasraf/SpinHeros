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
    [SerializeField] IntEvent AIAutoAttack_ID;
    [SerializeField] VoidEvent CommonFishCatch;
    [SerializeField] VoidEvent RareFishCatch;
    [SerializeField] VoidEvent DreamFishCatch;
    [SerializeField] VoidEvent SharkCatch;
    [SerializeField] VoidEvent BootCatch;

    public void CheckWheelResult()
    {
        CheckPrize(0);
    }

    public void CheckPrize(int id)
    {
        switch (_spiningWheelData.results[id])
        {
            case 0:
                CommonFishCatch.Raise();
                _playersData[id].score += _spiningWheelData.fishPrize;
                _playersData[id].currentPrize = _spiningWheelData.fishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();
                break;

            case 1:
                if (id == 0)
                {
                    ChooseCharacter.Raise();
                }
                else
                {

                    if (_miniGameData.playerAlive > 1)
                    {
                        SharkCatch.Raise();
                        AIAutoAttack_ID.Raise(id);
                    }
                    else
                    {
                        break;
                    }
                }

                break;

            case 2:
                BootCatch.Raise();
                _playersData[id].score += _spiningWheelData.shoePrize;
                _playersData[id].currentPrize = _spiningWheelData.shoePrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();
                break;

            case 3:
                DreamFishCatch.Raise();
                _playersData[id].score += _spiningWheelData.legnderyFishPrize;
                _playersData[id].currentPrize = _spiningWheelData.legnderyFishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();

                break;

            case 4:
                RareFishCatch.Raise();
                _playersData[id].score += _spiningWheelData.rareFishPrize;
                _playersData[id].currentPrize = _spiningWheelData.rareFishPrize;
                PlayerID_Anim_FishPrize.Raise(id);
                Score_Update.Raise();
                break;
        }
    }
}
