using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInput : MonoBehaviour
{
    [SerializeField] VoidEvent backButtonIsPressed;

    public void BackButton_Listener() {
        backButtonIsPressed.Raise();
    }
}
