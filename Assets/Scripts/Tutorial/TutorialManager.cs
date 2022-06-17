using UnityEngine;

class TutorialManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] GameSettingsData _gameSettingsData;

    private void Start()
    {
        if (_gameSettingsData.TutorialMode) {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
