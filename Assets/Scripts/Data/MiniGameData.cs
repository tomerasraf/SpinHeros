using UnityEngine;

[CreateAssetMenu(fileName = "MiniGameData", menuName = "Data/MiniGameData", order = 0)]
public class MiniGameData : ScriptableObject
{
    public bool gameIsOver = false;
    public int playersGoal = 1500;
}