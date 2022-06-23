using UnityEngine;

[CreateAssetMenu(fileName = "SystemData", menuName = "Data/SystemData")]
public class SystemData : ScriptableObject
{
    public bool inMenu = false;
    public bool cameraIsFocusedOnWheel = false;
}