using UnityEngine;

public class MiniGameInput : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData _playerData;

    [Header("Events")]
    [SerializeField] VoidEvent enterMiniGame_Event;
    [SerializeField] VoidEvent minigameUIText_Updater;
    [SerializeField] VoidEvent focuseOnWheel;
    public void MiniGameEvent_Trigger()
    {
        focuseOnWheel.Raise();

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