using UnityEngine;

public class BuildMode : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] WorldData _worldData;

    public void BuildingModeIsOn()
    {
        _worldData.buldingModeIsOn = true;
    }

    private void Building_UI_TouchInput()
    {

    }
}