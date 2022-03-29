using UnityEngine;

[CreateAssetMenu(fileName = "SpiningWheelData", menuName = "SpiningWheel")]
public class SpiningWheelData : ScriptableObject
{
    public int[] wheelsSlots;
    public int[] results;
    public int fishPrize = 10;
    public int rareFishPrize = 20;
    public int legnderyFishPrize = 50;
    public int shoePrize = -10;
}