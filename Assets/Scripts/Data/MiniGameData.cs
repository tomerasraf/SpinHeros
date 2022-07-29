using UnityEngine;

[CreateAssetMenu(fileName = "MiniGameData", menuName = "Data/MiniGameData", order = 0)]
public class MiniGameData : ScriptableObject
{
    [Header("Mini Game Status")]
    public int playersGoal = 250;
    public bool gameIsOver = false;
    public int playerAlive = 4;

    [Header("Mini Game Prizes")]
    public int winnerPrize = 50000;
    public int loserPrize = 10000;
    public int winnerSpinPrize = 20;
    public int loserSpinPrize = 5;
    public int attackBonus = 2000;
}