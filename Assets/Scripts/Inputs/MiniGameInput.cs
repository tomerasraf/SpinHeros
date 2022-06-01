using UnityEngine;

public class MiniGameInput : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] VoidEvent enterMiniGame_Event;
    [SerializeField] VoidEvent minigameUIText_Updater;

    public void MiniGameEvent_Trigger()
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