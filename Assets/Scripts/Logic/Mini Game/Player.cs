using UnityEngine;

public class Player
{
    private int id;
    private int hearts;
    private int playerPlace;
    private float score;

    public Player(int ID, int Hearts, int PlayerPlace, float Score)
    {
        id = ID;
        hearts = Hearts;
        playerPlace = PlayerPlace;
        score = Score;
    }

}