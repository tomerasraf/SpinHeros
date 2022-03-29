using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlayerData player;

    private void Start()
    {
        player.hearts = 3;
        player.playerPlace = 4;
        player.playerProgress = 0;
        player.score = 0;
    }
}
