using UnityEngine;

[CreateAssetMenu(fileName = "WorldData", menuName = "RaceGambling3D/WorldData", order = 0)]
public class WorldData : ScriptableObject
{
    public bool buldingModeIsOn;
    public int[] curentBuildingData;
    public float satisfactionBar;
}