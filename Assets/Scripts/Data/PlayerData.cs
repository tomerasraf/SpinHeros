using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    // Slot Machine Player Data

    [Header("Slot Machine Player Data")]

    public int coins = 0;
    public int crowns = 0;
    public int spins = 50;
    public int maxSpins = 50;
    public int extraSpins = 0;
    public float moreSpinsTimer = 60;
    public int bet = 1;
    public int miniGameTicket = 0;

    [Header("Mini Game Player Data")]

    // Mini Game Player Data
    
    public float playerProgress = 0;
    public int score = 0;
    public int currentPrize = 0;
    public int amountPlayersAttacked = 0;

    [Header("Fly&Avoid Mini Game Player Data")]
    public float playerIsImmuneTime = 0;
    public int giftsCollected = 0;
    public int spinsCollected = 0;
    public int coinsCollected = 0;

    [Header("Global Vars")]
    public int hearts;
    public bool playerIsDead = false;
}
