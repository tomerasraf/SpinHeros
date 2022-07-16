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

            LeftTap.Raise();
            SideToSideSound.Raise();
    }

    public void RightTapListener()
    {
        if (_playerData.playerIsDead) { return; }
            RightTap.Raise();
            SideToSideSound.Raise();
    }
}
