using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Fish : MonoBehaviour
{
    [SerializeField] Animator[] players;
    [SerializeField] GameObject fishPrefab;
    [SerializeField] DOTweenPath path;

    private float animDuration = 1.5f;

    public void startCatchFish_Coroutine(int playerID)
    {
        StartCoroutine(CatchFish_Anim(playerID));
    }

    IEnumerator CatchFish_Anim(int playerID)
    {
        players[playerID].SetBool("isSpining", true);
        if (playerID.ToString() == path.id)
        {
            path.DOPlay();
        }

        yield return new WaitForSeconds(animDuration);

        if (playerID.ToString() == path.id)
        {
            path.DORewind();
        }

        players[playerID].SetBool("isSpining", false);
        yield return null;
    }

}