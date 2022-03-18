using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public int coins = 0;
    public int spins = 50;
    public int maxSpins = 50;
    public int extraSpins = 0;
    public float moreSpinsTimer = 60;
    public int bet = 1;
    public int hearts;
}
