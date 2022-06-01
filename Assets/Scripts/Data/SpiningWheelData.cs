using UnityEngine;

[CreateAssetMenu(fileName = "SpiningWheelData", menuName = "Data/SpiningWheel")]
public class SpiningWheelData : ScriptableObject
{
    [Header("Wheel Result & Slots")]
    public int[] wheelsSlots;
    public int[] results;

    [Header("Prizes score")]
    public int fishPrize = 10;
    public int rareFishPrize = 20;
    public int legnderyFishPrize = 50;
    public int shoePrize = -10;
    public int choosenPlayer;

    [Header("Wheel Ods")]
    public int[] odds;
}