using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ReelMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float reelSpeed = 3f;

    [Header("Transform")]
    [SerializeField] Transform[] reels;

    [Header("Data")]
    [SerializeField] private SlotMachineData slotMachineData;
    [SerializeField] private PlayerData _playerData;

    [Header("Events")]
    [SerializeField] private VoidEvent SpinIsEnded;
    public Button spinButton;


    private float elapsedTime = 0;
    private bool isRolling = false;
    private float SymbolOffset = -70f;

    #region eventListeners 


    public void StartRollReelCoroutine()
    {
        if (_playerData.spins < 0) { return; }

        if (_playerData.spins >= 0)
        {
            isRolling = true;
            spinButton.enabled = false;
            StartCoroutine(ReelRoll(reels));
        }
    }
    #endregion

    IEnumerator ReelRoll(Transform[] reels)
    {
        elapsedTime = 0;
        float rand = Random.Range(0.6f, 1.5f);
        while (isRolling)
        {
            elapsedTime += Time.deltaTime;
            if (reels.Length == 1)
            {
                ReelRotation(reels[0], 0);
            }
            else
            {
                ReelRotation(reels[0], 0);
                ReelRotation(reels[1], 0.2f);
                ReelRotation(reels[2], 0.4f);
            }


            if (elapsedTime >= rand)
            {
                isRolling = false;
            }

            yield return null;
        }

        ReelStop();

        yield return new WaitForSeconds(2f);
        spinButton.enabled = true;
        SpinIsEnded.Raise();

        yield return null;
    }

    void ReelRotation(Transform reel, float delayTime)
    {
        Vector3 rotationVector = new Vector3(
            reel.transform.eulerAngles.x,
            reel.transform.eulerAngles.y,
            reel.transform.eulerAngles.z + SymbolOffset * Time.deltaTime * reelSpeed
         );

        Quaternion reelRotation = Quaternion.Euler(rotationVector);

        if (elapsedTime > delayTime)
            reel.transform.rotation = reelRotation;
    }

    void ReelStop()
    {
        float deltaStopSpeed = 0.5f;
        for (int i = 0; i <= reels.Length - 1; i++)
        {
            Vector3 rotationVector = new Vector3(
            reels[i].transform.eulerAngles.x,
            reels[i].transform.eulerAngles.y,
            // Fixes the issue with the sack of coins texure by adding +10 to the z rotaion axais.
            slotMachineData.slotResults[i] != 0 ? slotMachineData.slotResults[i] * SymbolOffset : slotMachineData.slotResults[i] + 10
            );

            reels[i].DORotate(rotationVector, deltaStopSpeed++, RotateMode.FastBeyond360).SetEase(Ease.OutBack);
        }
    }
}
