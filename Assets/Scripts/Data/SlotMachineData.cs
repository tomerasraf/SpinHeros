using UnityEngine;

[CreateAssetMenu(fileName = "New Slot Machine Data", menuName = "Slot Machine Data")]
public class SlotMachineData : ScriptableObject
{
    public int[] slot1;
    public int[] slot2;
    public int[] slot3;
    
    public int[] slotResults;

    //public int slot2Result;
    //public int slot3Result;

}
