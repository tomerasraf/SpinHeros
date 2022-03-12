using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelMovement : MonoBehaviour
{
    [SerializeField] float reelSpeed = 3f;
    [SerializeField] Transform[] Reels;
    float counter = 3f;
    float elapsedTime = 0;


    private float offset = 70f;

    public void StartReelRollCoroutine()
    {
        StartCoroutine(ReelRoll(Reels));
    }


    IEnumerator ReelRoll(Transform[] reels)
    {
        elapsedTime = 0;
        while (elapsedTime < counter)
        {
            elapsedTime += Time.deltaTime;
            ReelRotation(reels[0]);
            yield return new WaitForSeconds(0.2f);
            ReelRotation(reels[1]);
            yield return new WaitForSeconds(0.2f);
            ReelRotation(reels[2]);

            yield return null;
        }

        yield return null;
    }

    void ReelRotation(Transform reel)
    {
        Vector3 rotationVector = new Vector3(
            reel.transform.eulerAngles.x,
            reel.transform.eulerAngles.y,
            reel.transform.eulerAngles.z + offset 
         );

        Quaternion reelRotation = Quaternion.Euler(rotationVector);

        reel.transform.rotation = Quaternion.Lerp(reel.transform.rotation, reelRotation, (elapsedTime / counter));
    }
}
