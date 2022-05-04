using UnityEngine;

public class BuldingInput : MonoBehaviour
{
    [SerializeField] VoidEvent bulding_Mode;
    public void BuildingModeOn()
    {
        bulding_Mode.Raise();
    }
}