using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    public void TurnOffUI_Listener() {
        canvas.SetActive(false);
    }

    public void TurnOnUI_Listener() {
        canvas.SetActive(true);
    }
}
