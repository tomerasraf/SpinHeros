using System.Collections;
using UnityEngine;

public class MiniGameInput : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SystemData _systemData;
    [SerializeField] PlayerData _playerData;

    [Header("Events")]
    [SerializeField] VoidEvent enterMiniGame_Event;
    [SerializeField] VoidEvent minigameUIText_Updater;
    [SerializeField] VoidEvent focuseOnWheel;
    public void MiniGameEvent_Trigger()
    {
        focuseOnWheel.Raise();

        if (!_systemData.cameraIsFocusedOnWheel)
        {
            StartCoroutine(DelayAction());
        }
        else
        {
            if (_playerData.miniGameTicket > 0)
            {
                enterMiniGame_Event.Raise();
                _playerData.miniGameTicket--;
                minigameUIText_Updater.Raise();
            }
            else
            {
                return;
            }
        }

        
    }

    IEnumerator DelayAction()
    {

        yield return new WaitForSeconds(2f);

        if (_playerData.miniGameTicket > 0)
        {
            enterMiniGame_Event.Raise();
            _playerData.miniGameTicket--;
            minigameUIText_Updater.Raise();
        }
        else
        {
            yield return null;
        }

        yield return null;
    }

}