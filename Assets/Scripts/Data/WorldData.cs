using UnityEngine;

[CreateAssetMenu(fileName = "WorldData", menuName = "RaceGambling3D/WorldData", order = 0)]
public class WorldData : ScriptableObject
{
    [Header("BuildMode")]
    public bool buldingModeIsOn;
    [Header("Satisfaction Bar")]
    public float satisfactionBar;

    [Header("Building Prices")]
    public int house_1_Price = 25000;
    public int house_2_Price = 10000;
    public int house_3_Price = 40000;
    public int house_4_Price = 75000;
    public int house_5_Price = 100000;

    [Header("BuildingData")]
    public int[] ids;
    public int[] priceToBuild;
    public bool[] isBuilded;


}