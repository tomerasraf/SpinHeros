using UnityEngine;

class TutorialManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] GameSettingsData _gameSettingsData;

    [Header("Scenario")]
    [SerializeField] GameObject scenario;

    [Header("Event")]
    [SerializeField] VoidEvent tutorialModeIsOff;

    private void Start()
    {
        if (_gameSettingsData.tutorialMode)
        {
            gameObject.SetActive(true);
        }
        else
        {
            tutorialModeIsOff.Raise();
            scenario.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
