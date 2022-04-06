using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fish : MonoBehaviour
{
    [SerializeField] Animator[] players;
    [SerializeField] GameObject fishPrefab;

    private float animDuration = 1.03f;

    public void startCatchFish_Coroutine(int playerID)
    {
        StartCoroutine(CatchFish_Anim(playerID));
    }

    IEnumerator CatchFish_Anim(int playerID)
    {
        players[playerID].SetBool("isSpining", true);
        yield return new WaitForSeconds(animDuration);
        players[playerID].SetBool("isSpining", false);
        yield return null;
    }

}