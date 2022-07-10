using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] FlyAndAvoidData _flyAndAvoidData;

    [Header("Vars")]
    [SerializeField] float meteorStartOffset;
    [SerializeField] float timeBetweenSpwan; 

    [Header("GameObjects & Transforms")]
    [SerializeField] GameObject meteorPrefab;
    [SerializeField] Transform player;
   
    IEnumerator Start()
    {

        while (!_flyAndAvoidData.gameIsEnded)
        {
            float randXAxisPos = Random.Range(-2, 3);

            Vector3 meteorStartPos = new Vector3(
                randXAxisPos,
                player.position.y + meteorStartOffset,
                player.position.z
                );

            Instantiate(meteorPrefab, meteorStartPos, Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenSpwan);

            yield return null;
        }

        yield return null;

    }


}
