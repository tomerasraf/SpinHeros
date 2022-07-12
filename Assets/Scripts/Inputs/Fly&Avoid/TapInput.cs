using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapInput : MonoBehaviour
{
    [SerializeField] VoidEvent RightTap;
    [SerializeField] VoidEvent LeftTap;
    [SerializeField] VoidEvent SideToSideSound;

    public void LeftTapListener() {
        LeftTap.Raise();
        SideToSideSound.Raise();
    }

    public void RightTapListener() {
        RightTap.Raise();
        SideToSideSound.Raise();
    }
}
