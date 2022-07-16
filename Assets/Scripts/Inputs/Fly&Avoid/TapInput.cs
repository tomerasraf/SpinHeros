using UnityEngine;

public class TapInput : MonoBehaviour
{

    [Header("Data")]
    [SerializeField] PlayerData _playerData;

    [Header("Events")]
    [SerializeField] VoidEvent RightTap;
    [SerializeField] VoidEvent LeftTap;
   

    public void LeftTapListener()
    {
        if (_playerData.playerIsDead) { return; }
            LeftTap.Raise();
    }

    public void RightTapListener()
    {
        if (_playerData.playerIsDead) { return; }
            RightTap.Raise();
    }
}
