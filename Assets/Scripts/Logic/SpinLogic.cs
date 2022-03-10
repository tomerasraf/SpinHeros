using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLogic : MonoBehaviour
{
    private int[] slot1 = { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5 };
    private int[] slot2 = { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5 };
    private int[] slot3 = { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5 };
    private int slot1Result;
    private int slot2Result;
    private int slot3Result;

    [SerializeField] float timeOfSpin = 1f;

    [SerializeField] private bool isButtonPressed = false;

    public void PressButton()
    {
        isButtonPressed = true;

        RanomizeSpin(slot1, slot1Result);
        RanomizeSpin(slot2, slot2Result);
        RanomizeSpin(slot3, slot3Result);
    }

    private void Update()
    {
        if (isButtonPressed)
        {
            timeOfSpin -= Time.deltaTime;
            if (timeOfSpin <= 0)
            {
                isButtonPressed = false;
                timeOfSpin = 1f;
            }
        }
    }

    private void RanomizeSpin(int[] slot, int result)
    {
        int rand = Random.Range(0, slot.Length);
        result = slot[rand];
    }
}
