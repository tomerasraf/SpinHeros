using UnityEngine;

class TutorialManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] GameSettingsData _gameSettingsData;

    [Header("Scenario")]
    [SerializeField] GameObject scenario;

    private void Start()
    {
        if (_gameSettingsData.TutorialMode) {
            gameObject.SetActive(true);
        }
        else
        {
            scenario.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
