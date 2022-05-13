using UnityEngine;

public class MiniGameInput : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] VoidEvent enterMiniGame_Event;

    public void MiniGameEvent_Trigger()
    {
        enterMiniGame_Event.Raise();
    }

}