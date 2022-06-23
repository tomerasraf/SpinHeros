using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeLogic : MonoBehaviour
{
    [SerializeField] SlotMachineData _slotMachineData;
    [SerializeField] PlayerData _playerData;

    [Header("Events")]
    [SerializeField] VoidEvent JackpotSound;
    [SerializeField] VoidEvent miniGameTicketIsEarned;
    [SerializeField] VoidEvent spinIsEarned;
    [SerializeField] VoidEvent heartIsEarned;
    [SerializeField] VoidEvent coinIsEarned;


    public void CheckResultsCaller()
    {
        CheckResults(_slotMachineData.slotResults);
    }

    void CheckResults(int[] results)
    {
        // Coin Jackpot Check
        if (_slotMachineData.slotResults[0] == 1
         && _slotMachineData.slotResults[1] == 1
          && _slotMachineData.slotResults[2] == 1)
        {
            // Coin Prize
            JackpotSound.Raise();
            _playerData.coins += _slotMachineData.coinJackpotPrize * _playerData.bet;
            _slotMachineData.CurrentPrize = _slotMachineData.coinJackpotPrize * _playerData.bet;
            coinIsEarned.Raise();
        }

        // Stash Of Coins Jackpot Check
        if (_slotMachineData.slotResults[0] == 0
         && _slotMachineData.slotResults[1] == 0
          && _slotMachineData.slotResults[2] == 0)
        {
            // Stash Of Coins Prize
            JackpotSound.Raise();
            _playerData.coins += _slotMachineData.StashJackpotPrize * _playerData.bet;
            _slotMachineData.CurrentPrize = _slotMachineData.StashJackpotPrize * _playerData.bet;
            coinIsEarned.Raise();
        }

        // Hearts Check
        if (_slotMachineData.slotResults[0] == 4
         && _slotMachineData.slotResults[1] == 4
         && _slotMachineData.slotResults[2] == 4)
        {
            // Hearts Prize
            _playerData.hearts += 1 * _playerData.bet;

            if (_playerData.hearts > 3)
            {
                _playerData.hearts = 3;
            }

            heartIsEarned.Raise();
        }

        // Spins Check
        if (_slotMachineData.slotResults[0] == 3
         && _slotMachineData.slotResults[1] == 3
         && _slotMachineData.slotResults[2] == 3)
        {
            // Spin Prize 
            _playerData.spins += 15 * _playerData.bet;
          
            spinIsEarned.Raise();
        }

        // Mini Game Check
        if (_slotMachineData.slotResults[0] == 2
            && _slotMachineData.slotResults[1] == 2
            && _slotMachineData.slotResults[2] == 2)
        {
            // Mini Game Prize
            _playerData.miniGameTicket++;
            miniGameTicketIsEarned.Raise();
        }

        // 2 Coins Check
        if (_slotMachineData.slotResults[0] == 1
         && _slotMachineData.slotResults[1] == 1
          && _slotMachineData.slotResults[2] != 1
           || _slotMachineData.slotResults[1] == 1
            && _slotMachineData.slotResults[2] == 1
             && _slotMachineData.slotResults[0] != 1 ||
             _slotMachineData.slotResults[0] == 1
             && _slotMachineData.slotResults[1] != 1
              && _slotMachineData.slotResults[2] == 1)
        {
            // 2 Coins Prize
            _playerData.coins += _slotMachineData.twoCoinsPrize * _playerData.bet;
            _slotMachineData.CurrentPrize = _slotMachineData.twoCoinsPrize * _playerData.bet;
            coinIsEarned.Raise();
        }

        // One Coin Prize
        if (_slotMachineData.slotResults[0] == 1 && _slotMachineData.slotResults[1] != 1 && _slotMachineData.slotResults[2] != 1 ||
         _slotMachineData.slotResults[1] == 1 && _slotMachineData.slotResults[0] != 1 && _slotMachineData.slotResults[2] != 1 ||
          _slotMachineData.slotResults[2] == 1 && _slotMachineData.slotResults[1] != 1 && _slotMachineData.slotResults[0] != 1)
        {
            _playerData.coins += _slotMachineData.oneCoinPrize * _playerData.bet;
            _slotMachineData.CurrentPrize = _slotMachineData.oneCoinPrize * _playerData.bet;
            coinIsEarned.Raise();
        }

        // 2 Stash Of Coins Check
        if (_slotMachineData.slotResults[0] == 0
         && _slotMachineData.slotResults[1] == 0
          && _slotMachineData.slotResults[2] != 0
           || _slotMachineData.slotResults[1] == 0
            && _slotMachineData.slotResults[2] == 0
             && _slotMachineData.slotResults[0] != 0
              || _slotMachineData.slotResults[0] == 0
             && _slotMachineData.slotResults[1] != 0
              && _slotMachineData.slotResults[2] == 0)
        {
            // 2 Stash Prize
            _playerData.coins += _slotMachineData.twoStashPrize * _playerData.bet;
            _slotMachineData.CurrentPrize = _slotMachineData.twoStashPrize * _playerData.bet;
            coinIsEarned.Raise();
        }

        // One Stash Prize
        if (_slotMachineData.slotResults[0] == 0 && _slotMachineData.slotResults[1] != 0 && _slotMachineData.slotResults[2] != 0 ||
         _slotMachineData.slotResults[1] == 0 && _slotMachineData.slotResults[0] != 0 && _slotMachineData.slotResults[2] != 0 ||
          _slotMachineData.slotResults[2] == 0 && _slotMachineData.slotResults[1] != 0 && _slotMachineData.slotResults[0] != 0)
        {
            _playerData.coins += _slotMachineData.oneStashPrize * _playerData.bet;
            _slotMachineData.CurrentPrize = _slotMachineData.oneStashPrize * _playerData.bet;
            coinIsEarned.Raise();
        }
    }
}
