using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Fish : MonoBehaviour
{

    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Prefabs")]
    [SerializeField] GameObject fishPrefab;
    [SerializeField] GameObject rareFish;
    [SerializeField] GameObject leganderyFish;

    [Header("Players Animators")]
    [SerializeField] Animator[] players;

    [Header("DOTweenPath")]
    [SerializeField] DOTweenPath path;
    private GameObject fishClone;

    enum Prizes { Fish = 4, GoldenFish = 7, DreamFish = 3 }
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
            SpawnFish(playerID);
            path.DOPlay();
        }

        yield return new WaitForSeconds(animDuration);

        if (playerID.ToString() == path.id)
        {
            path.DORewind();
            Destroy(fishClone);
        }

        players[playerID].SetBool("isSpining", false);
        yield return null;
    }

    private void SpawnFish(int playerID)
    {
        int fishPrize = (int)Prizes.Fish;
        int goldFishPrize = (int)Prizes.GoldenFish;
        int dreamFishPrize = (int)Prizes.DreamFish;

        if (_spiningWheelData.results[playerID] == fishPrize)
        {
            fishClone = Instantiate(fishPrefab, path.transform.position, Quaternion.identity);
            fishClone.transform.parent = path.transform;
        }
        else if (_spiningWheelData.results[playerID] == goldFishPrize)
        {
            fishClone = Instantiate(rareFish, path.transform.position, Quaternion.identity);
            fishClone.transform.parent = path.transform;
        }
        else if (_spiningWheelData.results[playerID] == dreamFishPrize)
        {
            fishClone = Instantiate(leganderyFish, path.transform.position, Quaternion.identity);
            fishClone.transform.parent = path.transform;
        }

    }
}