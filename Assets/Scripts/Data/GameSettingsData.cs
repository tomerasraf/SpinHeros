using UnityEngine;


[CreateAssetMenu(fileName = "GameSettingsData", menuName = "Data/GameSettingsData", order = 0)]
class GameSettingsData : ScriptableObject
{
    public bool tutorialMode;
    public bool buildControlsOff;
}
