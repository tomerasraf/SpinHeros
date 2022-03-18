using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeLogic : MonoBehaviour
{
    [SerializeField] SlotMachineData _slotMachineData;
    [SerializeField] PlayerData _playerData;
    [SerializeField] VoidEvent prizeIsEarned;
    [SerializeField] VoidEvent heartIsEarned;

    public void CheckResultsCaller()
    {
        CheckResults(_slotMachineData.slotResults);
    }

    void CheckResults(int[] results)
    {
        // Coin Jackpot Check
        if (_slotMachineData.slotResults[0] == 2
         && _slotMachineData.slotResults[1] == 2
          && _slotMachineData.slotResults[2] == 2)
        {
            // Coin Prize
            _playerData.coins += _slotMachineData.coinJackpotPrize * _playerData.bet;
            prizeIsEarned.Raise();
        }

        // Stash Of Coins Jackpot Check
        if (_slotMachineData.slotResults[0] == 0
         && _slotMachineData.slotResults[1] == 0
          && _slotMachineData.slotResults[2] == 0)
        {
            // Stash Of Coins Prize
            _playerData.coins += _slotMachineData.StashJackpotPrize * _playerData.bet;
            prizeIsEarned.Raise();
        }

        // Hearts Check
        if (_slotMachineData.slotResults[0] == 4
         && _slotMachineData.slotResults[1] == 4
         && _slotMachineData.slotResults[2] == 4)
        {
            // Hearts Prize
            _playerData.hearts += 3 * _playerData.bet;
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
            if (_playerData.spins < _playerData.maxSpins)
            {
                _playerData.spins += 3 * _playerData.bet;
            }
            else
            {
                _playerData.spins = _playerData.maxSpins;
                _playerData.extraSpins += 3;
            }

            prizeIsEarned.Raise();
        }

        // Mini Game Check
        if (_slotMachineData.slotResults[0] == 1
            && _slotMachineData.slotResults[1] == 1
            && _slotMachineData.slotResults[2] == 1)
        {
            // Mini Game Prize
            Debug.Log("Mini Game");
            prizeIsEarned.Raise();
        }

        // 2 Coins Check
        if (_slotMachineData.slotResults[0] == 2
         && _slotMachineData.slotResults[1] == 2
          && _slotMachineData.slotResults[2] != 2
           || _slotMachineData.slotResults[1] == 2
            && _slotMachineData.slotResults[2] == 2
             && _slotMachineData.slotResults[0] != 2)
        {
            // 2 Coins Prize
            _playerData.coins += _slotMachineData.twoCoinsPrize * _playerData.bet;
            prizeIsEarned.Raise();
        }

        // 2 Stash Of Coins Check
        if (_slotMachineData.slotResults[0] == 0
         && _slotMachineData.slotResults[1] == 0
          && _slotMachineData.slotResults[2] != 0
           || _slotMachineData.slotResults[1] == 0
            && _slotMachineData.slotResults[2] == 0
             && _slotMachineData.slotResults[0] != 0)
        {
            // 2 Stash Prize
            _playerData.coins += _slotMachineData.twoStashPrize * _playerData.bet;
            prizeIsEarned.Raise();
        }
    }
}
