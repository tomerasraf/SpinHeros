using UnityEngine;

public class SpinLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]
    private SlotMachineData _slotMachineData;

    [SerializeField]
    private PlayerData _playerData;

    [Header("Events")]

    [SerializeField]
    VoidEvent spinBar_Updater;

    private void Update()
    {
        SpinRefillLogic();
        ExtraSpinLogic();
    }

    public void Spin()
    {
        if (_playerData.spins < 0)
        {
            return;
        }

        _playerData.spins -= _playerData.bet;

        spinBar_Updater.Raise();

        RanomizeSpin(_slotMachineData.slot1,
        out _slotMachineData.slotResults[0]);
        RanomizeSpin(_slotMachineData.slot2,
        out _slotMachineData.slotResults[1]);
        RanomizeSpin(_slotMachineData.slot3,
        out _slotMachineData.slotResults[2]);
    }

    private void SpinRefillLogic()
    {
        if (_playerData.spins < 0)
        {
            _playerData.spins = 0;
        }

        if (_playerData.spins >= _playerData.maxSpins)
        {
            return;
        }

        _playerData.moreSpinsTimer -= Time.deltaTime;

        if (_playerData.moreSpinsTimer <= 0)
        {
            _playerData.spins += 5;
            _playerData.moreSpinsTimer = 60f;
            spinBar_Updater.Raise();
        }
    }

    private void ExtraSpinLogic()
    {
        if (_playerData.spins > _playerData.maxSpins)
        {
            _playerData.extraSpins = _playerData.spins % _playerData.maxSpins;
            spinBar_Updater.Raise();
        }
    }

    // Randomize the slot machine reel symbol number
    private void RanomizeSpin(int[] slot, out int result)
    {
        int rand = Random.Range(0, slot.Length);
        result = slot[rand];
    }
}
