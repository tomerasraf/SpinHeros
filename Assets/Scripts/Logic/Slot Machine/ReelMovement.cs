using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReelMovement : MonoBehaviour
{
    [Header("Wheel Control")]
    [SerializeField] private float reelSpeed = 3f;
    [SerializeField] float symbolOffset = 45f;
    [SerializeField] float wheelSpiningTime = 0.9f;
    [SerializeField] float firstReelstopTime = 0.8f;
    [SerializeField] float nextReelIncrementTime = 0.35f;

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
    private float tempStopTime;


    private void Start()
    {
        tempStopTime = firstReelstopTime;
    }

    #region eventListeners 

    public void EnterMiniGame_Listener()
    {
        LowerWheelAnimation();
    }

    private void LowerWheelAnimation()
    {
        for (int i = 0; i < reels.Length; i++)
        {
            reels[i].DOMoveY(-2f, 3f);
        }
    }

    public void StartRollReelCoroutine()
    {
        if (_playerData.spins > -1)
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

            if (elapsedTime >= wheelSpiningTime)
            {
                isRolling = false;
            }

            yield return null;
        }

        ReelStop();

        yield return new WaitForSeconds(1.5f);
        spinButton.enabled = true;
        SpinIsEnded.Raise();

        yield return null;
    }

    void ReelRotation(Transform reel, float delayTime)
    {
        Vector3 rotationVector = new Vector3(
            reel.transform.eulerAngles.x,
            reel.transform.eulerAngles.y + symbolOffset * Time.deltaTime * reelSpeed,
            reel.transform.eulerAngles.z
         );

        Quaternion reelRotation = Quaternion.Euler(rotationVector);

        if (elapsedTime > delayTime)
            reel.transform.rotation = reelRotation;
    }

    void ReelStop()
    {
        firstReelstopTime = tempStopTime;
        for (int i = 0; i <= reels.Length - 1; i++)
        {
            Vector3 rotationVector = new Vector3(
            reels[i].transform.eulerAngles.x,
            slotMachineData.slotResults[i] * symbolOffset + 360 - 3.245f,
            reels[i].transform.eulerAngles.z
            );

            firstReelstopTime += nextReelIncrementTime;
            reels[i].DORotate(rotationVector, firstReelstopTime, RotateMode.FastBeyond360).SetEase(Ease.InSine).SetEase(Ease.OutBack);
        }
    }
}
