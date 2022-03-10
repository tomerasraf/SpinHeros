using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinInput : MonoBehaviour
{
    [SerializeField] private VoidEvent SpinButtonPressed;
    [SerializeField] private bool isButtonPressed;
    public void SpinInputHandler()
    {
        SpinButtonPressed.Raise();
    }
}
