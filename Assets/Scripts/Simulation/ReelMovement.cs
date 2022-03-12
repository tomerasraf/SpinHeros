using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelMovement : MonoBehaviour
{
    [SerializeField] float reelSpeed = 3f;
    [SerializeField] Transform[] Reels;
    [SerializeField] SlotMachineData slotMachineData;
    float counter = 3f;
    float elapsedTime = 0;
    float delayTime;

    bool isRolling;


    private float offset = -70f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G");
            isRolling = false;
        }    
    }

    public void StartReelRollCoroutine()
    {
        isRolling = true;
        StartCoroutine(ReelRoll(Reels));
    }


    IEnumerator ReelRoll(Transform[] reels)
    {
        elapsedTime = 0;
        while (isRolling)
        {
            elapsedTime += Time.deltaTime;
            ReelRotation(reels[0], 0);
            //yield return new WaitForSeconds(0.2f);
            ReelRotation(reels[1], 0.2f);
            //yield return new WaitForSeconds(0.2f);
            ReelRotation(reels[2], 0.4f);

            yield return null;
        }

        yield return null;
    }

    void ReelRotation(Transform reel, float delayTime)
    {
        Vector3 rotationVector = new Vector3(
            reel.transform.eulerAngles.x,
            reel.transform.eulerAngles.y,
            reel.transform.eulerAngles.z + offset * Time.deltaTime * reelSpeed
         );

        Quaternion reelRotation = Quaternion.Euler(rotationVector);

        if(elapsedTime > delayTime)
        reel.transform.rotation = reelRotation;
    }

    void ReelStop()
    {

    }
}
