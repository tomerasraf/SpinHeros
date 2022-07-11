using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] VoidEvent updateUI;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerData.hearts < 0) { return; } 
        _playerData.hearts--;
        updateUI.Raise();
    }
}
