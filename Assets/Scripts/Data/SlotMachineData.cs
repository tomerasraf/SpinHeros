using UnityEngine;

[CreateAssetMenu(fileName = "New Slot Machine Data", menuName = "Data/Slot Machine Data")]
public class SlotMachineData : ScriptableObject
{
    [Header("Mechine Symbols")]
    public int[] slot1;
    public int[] slot2;
    public int[] slot3;

    [Header("Mechine Results")]
    public int[] slotResults;

    [Header("Mechine Prizes")]
    public int CurrentPrize = 0;

    public int coinJackpotPrize = 1000;
    public int twoCoinsPrize = 300;
    public int oneCoinPrize = 120;

    public int StashJackpotPrize = 10000;
    public int twoStashPrize = 5000;
    public int oneStashPrize = 500;

    [Header("Machine Odds")]
    public int[] odds;

}
