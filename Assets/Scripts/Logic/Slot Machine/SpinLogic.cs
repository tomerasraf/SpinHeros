using UnityEngine;

public class SpinLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SlotMachineData _slotMachineData;
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameSettingsData _gameSettingsData;

    [Header("Events")]

    [SerializeField]
    VoidEvent spinBar_Updater;

    private int sequenceStage = 0;

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

        if (_gameSettingsData.TutorialMode)
        {

            if (sequenceStage == 0 || sequenceStage == 1)
            {
                TutorialSpin(1);
            }
            else if (sequenceStage == 2 || sequenceStage == 4 || sequenceStage == 5)
            {
                TutorialSpin(0);
            }
            else if (sequenceStage == 3)
            {
                TutorialSpin(4);
            }
            else if (sequenceStage == 6)
            {
                TutorialSpin(2);
            }
        }
        else
        {
            RanomizeSpin(_slotMachineData.slot1,
            out _slotMachineData.slotResults[0]);
            RanomizeSpin(_slotMachineData.slot2,
            out _slotMachineData.slotResults[1]);
            RanomizeSpin(_slotMachineData.slot3,
            out _slotMachineData.slotResults[2]);
        }


    }

    private void TutorialSpin(int symbolID)
    {
        for (int i = 0; i < _slotMachineData.slotResults.Length; i++)
        {
            _slotMachineData.slotResults[i] = symbolID;
        }
        sequenceStage++;
        Debug.Log(sequenceStage);
    }


    private void SpinRefillLogic()
    {
        if (_playerData.spins <= 0)
        {
            _playerData.spins = -1;
        }

        if (_playerData.spins >= _playerData.maxSpins)
        {
            return;
        }

        _playerData.moreSpinsTimer -= Time.deltaTime;

        if (_playerData.moreSpinsTimer <= 0)
        {
            if (_playerData.spins < 0)
            {
                _playerData.spins = 0;
            }

            _playerData.spins += 5;
            spinBar_Updater.Raise();
            _playerData.moreSpinsTimer = 60f;
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
