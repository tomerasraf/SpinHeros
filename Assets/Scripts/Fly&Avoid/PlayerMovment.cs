using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] FlyAndAvoidData _flyAndAvoidData;

    [Header("Vars")]
    [SerializeField] float playerFlightSpeed;
    [SerializeField] float miniGamePlayTime;
    [SerializeField] float gameStartDelay;

    [Header("Animation Vars")]
    [SerializeField] float playerSideToSideSpeed;
    [SerializeField] float flipAnimationTime;
    [SerializeField] float returnIdleFlightTime;

    [Header("Transforms")]
    [SerializeField] Transform playerLeftPos;
    [SerializeField] Transform playerRightPos;

    [Header("Events call")]
    [SerializeField] VoidEvent gameIsEnded;

    private bool playerIsLeftSide = false;
    private bool playerIsRightSide = false;

    private void Start()
    {
        FlyUpwardsForce();
    }

    public void MovePlayerLeft()
    {
        if (playerIsLeftSide) { return; }

        playerIsLeftSide = true;
        playerIsRightSide = false;

        transform.DOMoveX(playerLeftPos.position.x, playerSideToSideSpeed);
        transform.DORotate(new Vector3(transform.rotation.x, 360, transform.rotation.z), flipAnimationTime).OnComplete(() =>
        {
            transform.DORotate(new Vector3(transform.rotation.x, -180, transform.rotation.z), returnIdleFlightTime);
        });
    }

    public void MovePlayerRight()
    {
        if (playerIsRightSide) { return; }

        playerIsRightSide = true;
        playerIsLeftSide = false;

        transform.DOMoveX(playerRightPos.position.x, playerSideToSideSpeed);
        transform.DORotate(new Vector3(transform.rotation.x, 360, transform.rotation.z), flipAnimationTime).OnComplete(() =>
        {
            transform.DORotate(new Vector3(transform.rotation.x, -180, transform.rotation.z), returnIdleFlightTime);
        });
    }

    private void FlyUpwardsForce()
    {
        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        yield return new WaitForSeconds(gameStartDelay);

        while (miniGamePlayTime > 0)
        {
            Vector3 playerFlyingDiraction = new Vector3(
                transform.position.x,
                transform.position.y + playerFlightSpeed * Time.deltaTime,
                transform.position.z
                );

            transform.position = playerFlyingDiraction;

            miniGamePlayTime -= Time.deltaTime;

            yield return null;
        }

        _flyAndAvoidData.gameIsEnded = true;
        gameIsEnded.Raise();

        yield return null;
    }
}
