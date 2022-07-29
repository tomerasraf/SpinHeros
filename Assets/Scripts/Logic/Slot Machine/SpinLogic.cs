using UnityEngine;

public class SpinLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SlotMachineData _slotMachineData;
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameSettingsData _gameSettingsData;

    [Header("Events")]
    [SerializeField] VoidEvent spinBar_Updater;
    [SerializeField] VoidEvent coinTutorialMassage;
    [SerializeField] VoidEvent heartTutorialMassage;
    [SerializeField] VoidEvent miniGameTutorialMassage;

    [Header("Odds Vars")]
    [SerializeField] float firstChance;
    [SerializeField] float secondChance;

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

        if (_gameSettingsData.tutorialMode)
        {

            if (sequenceStage == 0)
            {
                TutorialSpin(1);
                coinTutorialMassage.Raise();
            }
            else if (sequenceStage == 1 || sequenceStage == 2 || sequenceStage == 4 || sequenceStage == 5)
            {
                TutorialSpin(0);
            }
            else if (sequenceStage == 3)
            {
                TutorialSpin(4);
                heartTutorialMassage.Raise();
            }
            else if (sequenceStage == 6)
            {
                TutorialSpin(2);
                miniGameTutorialMassage.Raise();
            }
        }
        else
        {
            RanomizeSpin();
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
        if (_gameSettingsData.tutorialMode) { return; }

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
    private void RanomizeSpin()
    {

        int rand = Random.Range(0, 5);

        _slotMachineData.slotResults[0] = rand;

        if (Random.value <= firstChance)
        {
            _slotMachineData.slotResults[1] = rand;
        }
        else
        {
            rand = Random.Range(0, 5);
            _slotMachineData.slotResults[1] = rand;
        }

        if (_slotMachineData.slotResults[0] == _slotMachineData.slotResults[1]) {

            if (Random.value <= secondChance) {
                _slotMachineData.slotResults[2] = rand;
            }

        }
        else
        {
            rand = Random.Range(0, 5);
            _slotMachineData.slotResults[2] = rand;
        }
            
    }
}
