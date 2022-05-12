using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    // Slot Machine Player Data
    public int coins = 0;
    public int crowns = 0;
    public int spins = 50;
    public int maxSpins = 50;
    public int extraSpins = 0;
    public float moreSpinsTimer = 60;
    public int bet = 1;
    public int miniGameTicket = 0;

    // Mini Game Player Data
    public int hearts;
    public int playerPlace = 4;
    public float playerProgress = 0;
    public int score = 0;
    public int maxScore = 300;
}
