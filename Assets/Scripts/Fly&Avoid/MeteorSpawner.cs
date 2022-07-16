using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
   

    [Header("Data")]
    [SerializeField] FlyAndAvoidData _flyAndAvoidData;

    [Header("Vars")]
    [SerializeField] float meteorStartOffset;
    [SerializeField] float meteorFalingSpeed;
    [SerializeField] float timeBetweenSpwan;

    [Header("GameObjects & Transforms")]
    [SerializeField] GameObject[] meteorPrefab;
    [SerializeField] Transform player;

    [SerializeField] VoidEvent debriesFlaingDownSFX;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        
            debriesFlaingDownSFX.Raise();

        while (_flyAndAvoidData.miniGamePlayTime > 3)
        {
            float randXAxisPos = Random.Range(-2, 3);

            Vector3 meteorStartPos = new Vector3(
                randXAxisPos,
                player.position.y + meteorStartOffset,
                player.position.z
                );

            int randMeteor = Random.Range(0, meteorPrefab.Length);

            Instantiate(
           meteorPrefab[randMeteor],
           meteorStartPos,
           Quaternion.identity
           );

          

            yield return new WaitForSeconds(timeBetweenSpwan);

            debriesFlaingDownSFX.Raise();
            yield return null;
        }

        yield return null;

    }


}
