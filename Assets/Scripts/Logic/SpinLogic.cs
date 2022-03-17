using UnityEngine;


public class SpinLogic : MonoBehaviour
{
    [SerializeField] SlotMachineData _slotMachineData;
    [SerializeField] PlayerData _playerData;

    private void Start()
    {
        _playerData.bet = 1;
        _playerData.spins = 50;
        _playerData.coins = 0;
    }

    public void Spin()
    {
        _playerData.spins -= _playerData.bet;

        RanomizeSpin(_slotMachineData.slot1, out _slotMachineData.slotResults[0]);
        RanomizeSpin(_slotMachineData.slot2, out _slotMachineData.slotResults[1]);
        RanomizeSpin(_slotMachineData.slot3, out _slotMachineData.slotResults[2]);

        if (_playerData.spins <= 0)
        {
            _playerData.spins = 0;
        }
    }

    // Randomize the slot machine reel symbol number
    private void RanomizeSpin(int[] slot, out int result)
    {
        int rand = Random.Range(0, slot.Length);
        result = slot[rand];
    }
}
