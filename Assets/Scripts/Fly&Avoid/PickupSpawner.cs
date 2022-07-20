using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] FlyAndAvoidData _flyAndAvoidData;

    [Header("GameObjects & Transforms")]
    [SerializeField] Transform player;
    [SerializeField] GameObject[] pickupObjectPrefabs;
 
    [Header("Vars")]
    [SerializeField] float ObjectStartUpwardsOffset;
    [SerializeField] float timeBetweenSpwan;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);

        while (_flyAndAvoidData.miniGamePlayTime > 3)
        {
            int randXAxisPos = Random.Range(-2, 3);

            Vector3 objectStartPos = new Vector3(
                randXAxisPos,
                player.position.y + ObjectStartUpwardsOffset,
                player.position.z
                );

            int randomPickup = Random.Range(0, 3);

            Instantiate(
           pickupObjectPrefabs[randomPickup],
           objectStartPos,
           Quaternion.identity
           );

            yield return new WaitForSeconds(timeBetweenSpwan);

            yield return null;
        }

        yield return null;

    }
}
