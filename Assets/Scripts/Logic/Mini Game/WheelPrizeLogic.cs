using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPrizeLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;
    public void CheckWheelResult()
    {
        switch (_spiningWheelData.result)
        {
            case 0:
            
                break;
        }
    }
}
