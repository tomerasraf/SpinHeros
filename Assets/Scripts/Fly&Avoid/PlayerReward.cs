using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReward : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData _playerData;
    [SerializeField] FlyAndAvoidData _flyAndAvoidData;

    private bool isPlayerWon;
    public void Victory_Listener() {
        isPlayerWon = true;
        calculateMiniGamePrize(isPlayerWon);
    }
    
    public void Defeat_Listener() {
        isPlayerWon = false;
        calculateMiniGamePrize(isPlayerWon);
    }

   

    private void calculateMiniGamePrize(bool isPlayerWon) {
        //Calculate player coin prize
        _flyAndAvoidData.playerCurrentCoinPrize += isPlayerWon ? _flyAndAvoidData.defualtWonCoinPrize : _flyAndAvoidData.defualtLossCoinPrize + (_playerData.coinsCollected * _flyAndAvoidData.pickupCoinPrize);

        //Calculate player spin prize
        _flyAndAvoidData.playerCurrentSpinPrize += _playerData.spinsCollected;

        //Calculate player gift prize
        _flyAndAvoidData.playerCurrentGiftPrize += _playerData.giftsCollected;
    }
}
