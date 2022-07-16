using UnityEngine;

public class TapInput : MonoBehaviour
{

    [Header("Data")]
    [SerializeField] PlayerData _playerData;

    [Header("Events")]
    [SerializeField] VoidEvent RightTap;
    [SerializeField] VoidEvent LeftTap;
    [SerializeField] VoidEvent SideToSideSound;

    public void LeftTapListener()
    {
        if (_playerData.playerIsDead) { return; }

            SideToSideSound.Raise();
            LeftTap.Raise();
    }

    public void RightTapListener()
    {
        if (_playerData.playerIsDead) { return; }
            SideToSideSound.Raise();
            RightTap.Raise();
    }
}
