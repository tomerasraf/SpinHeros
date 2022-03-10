using UnityEngine;

public class SpinLogic : MonoBehaviour
{
    public SlotMachineData slotMachineData;

    public void PressButton()
    {
        RanomizeSpin(slotMachineData.slot1, slotMachineData.slot1Result);
        RanomizeSpin(slotMachineData.slot2, slotMachineData.slot2Result);
        RanomizeSpin(slotMachineData.slot3, slotMachineData.slot3Result);
    }

    // Random spin
    private void RanomizeSpin(int[] slot, int result)
    {
        int rand = Random.Range(0, slot.Length);
        result = slot[rand];
        Debug.Log(result);
    }
}
