using UnityEngine;


[CreateAssetMenu(fileName = "FlyAndAvoidData", menuName = "Data/FlyAndAvoidData", order = 0)]
class FlyAndAvoidData : ScriptableObject
{
    [Header("Mini Game")]
    public float miniGamePlayTime;
    public bool gameIsEnded;

    [Header("Default Prizes")]
    public int defualtWonCoinPrize;
    public int defualtLossCoinPrize;

    [Header("Pickup Prizes")]
    public int pickupCoinPrize;
    public int pickupSpinPrize;
    public int pickupGiftPrize;

    [Header("Current Prizes")]
    public int playerCurrentSpinPrize;
    public int playerCurrentCoinPrize;
    public int playerCurrentGiftPrize;
}
