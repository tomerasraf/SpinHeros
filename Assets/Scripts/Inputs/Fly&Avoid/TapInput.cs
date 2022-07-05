using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapInput : MonoBehaviour
{
    [SerializeField] VoidEvent RightTap;
    [SerializeField] VoidEvent LeftTap;

    public void LeftTapListener() {
        LeftTap.Raise();     
    }

    public void RightTapListener() {
        RightTap.Raise();
    }
}
