using UnityEngine;


public class SpinLogic : MonoBehaviour
{
    public SlotMachineData slotMachineData;

    public void PressButton()
    {
        RanomizeSpin(slotMachineData.slot1, out slotMachineData.slotResults[0]);
        RanomizeSpin(slotMachineData.slot2, out slotMachineData.slotResults[1]);
        RanomizeSpin(slotMachineData.slot3, out slotMachineData.slotResults[2]);

    }

    // Randomize the slot machine reel symbol number
    private void RanomizeSpin(int[] slot, out int result)
    {
        int rand = Random.Range(0, slot.Length);
        result = slot[rand];
        Debug.Log(result);
    }
}
