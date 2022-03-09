using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinInput : MonoBehaviour
{
    [SerializeField] private VoidEvent SpinButtonPressed;
    public void SpinInputHandler()
    {
        SpinButtonPressed.Raise();
    }
}
