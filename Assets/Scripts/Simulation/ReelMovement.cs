using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            ReelStop();
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
        for(int i = 0; i <= 2; i++)
        {
            Vector3 rotationVector = new Vector3(
            Reels[i].transform.eulerAngles.x,
            Reels[i].transform.eulerAngles.y,
            slotMachineData.slotResults[i] * offset
            );
            Reels[i].DORotate(rotationVector, i + 1.2f, RotateMode.FastBeyond360);
        }
    }
}
