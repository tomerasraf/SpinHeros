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
    [SerializeField] GameObject shoe_Prefab;

    [Header("Players Animators")]
    [SerializeField] Animator[] players;

    [Header("DOTweenPath")]
    [SerializeField] DOTweenPath path;

    private GameObject fishClone;
    private GameObject shoeClone;
    

    enum Prizes { Fish = 0, GoldenFish = 4, DreamFish = 3 , shoe = 2}
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
        int shoePrize = (int)Prizes.shoe;

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
        else if (_spiningWheelData.results[playerID] == shoePrize) {
            shoeClone = Instantiate(shoe_Prefab, path.transform.position, Quaternion.identity);
            shoeClone.transform.parent = path.transform;
        }

    }
}