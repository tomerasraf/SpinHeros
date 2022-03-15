using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeLogic : MonoBehaviour
{
    [SerializeField] SlotMachineData slotMachineData;

    public void CheckResultsCaller()
    {
        CheckResults(slotMachineData.slotResults);
    }

    void CheckResults(int[] results)
    {
        // Coin Jackpot Check
        if (slotMachineData.slotResults[0] == 2 && slotMachineData.slotResults[1] == 2 && slotMachineData.slotResults[2] == 2)
        {
            // Coin Prize
            Debug.Log("Prize 1,000");
        }

        // Stash Of Coins Jackpot Check
        if (slotMachineData.slotResults[0] == 0 && slotMachineData.slotResults[1] == 0 && slotMachineData.slotResults[2] == 0)
        {
            // Stash Of Coins Prize
            Debug.Log("Prize 10,000");
        }

        // Hearts Check
        if (slotMachineData.slotResults[0] == 4 && slotMachineData.slotResults[1] == 4 && slotMachineData.slotResults[2] == 4)
        {
            // Hearts Prize
            Debug.Log("Hearts");
        }

        // Spins Check
        if (slotMachineData.slotResults[0] == 3 && slotMachineData.slotResults[1] == 3 && slotMachineData.slotResults[2] == 3)
        {
            // Spin Prize 
            Debug.Log("3 Spins");
        }

        // Mini Game Check
        if (slotMachineData.slotResults[0] == 1 && slotMachineData.slotResults[1] == 1 && slotMachineData.slotResults[2] == 1)
        {
            // Mini Game Prize
            Debug.Log("Mini Game");
        }

        // 2 Coins Check
        if (slotMachineData.slotResults[0] == 2 && slotMachineData.slotResults[1] == 2 && slotMachineData.slotResults[2] != 2 || slotMachineData.slotResults[1] == 2 && slotMachineData.slotResults[2] == 2 && slotMachineData.slotResults[0] != 2)
        {
            // 2 Coins Prize
            Debug.Log("Prize 300");
        }

        // 2 Stash Of Coins Check
        if (slotMachineData.slotResults[0] == 0 && slotMachineData.slotResults[1] == 0 && slotMachineData.slotResults[2] != 0 || slotMachineData.slotResults[1] == 0 && slotMachineData.slotResults[2] == 0 && slotMachineData.slotResults[0] != 0)
        {
            // 2 Stash Of Coins Prize
            Debug.Log("Prize 5,000");
        }
    }



}
