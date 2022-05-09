using UnityEngine;

public class BuldingInput : MonoBehaviour
{
    [SerializeField] VoidEvent buldingModeIsOn;
    [SerializeField] VoidEvent buldingModeIsOff;
    [SerializeField] IntEvent Build;
    public void BuildingModeOn()
    {
        buldingModeIsOn.Raise();
    }

    public void BuildingModeOff()
    {
        buldingModeIsOff.Raise();
    }

    public void BuildingInProgress(int id)
    {
        Build.Raise(id);
    }
}