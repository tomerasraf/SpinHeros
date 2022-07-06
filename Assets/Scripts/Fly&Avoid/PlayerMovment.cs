using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] FlyAndAvoidData _flyAndAvoidData;

    [Header("Vars")]
    [SerializeField] float playerSideToSideSpeed;
    [SerializeField] float miniGamePlayTime;
    [SerializeField] float gameStartDelay;

    [Header("Transforms")]
    [SerializeField] Transform endGamePoint;
    [SerializeField] Transform playerLeftPos;
    [SerializeField] Transform playerRightPos;

    [Header("Events call")]
    [SerializeField] VoidEvent gameIsEnded;

    private Vector3 playerStartPos;

    private bool playerIsLeftSide = false;
    private bool playerIsRightSide = false;


    private void Start()
    {
        playerStartPos = transform.position;
        FlyUpwardsForce();
    }

    public void MovePlayerLeft()
    {
        if (playerIsLeftSide) { return; }

        playerIsLeftSide = true;
        playerIsRightSide = false;

        transform.DOMoveX(playerLeftPos.position.x, playerSideToSideSpeed);
        transform.DORotate(new Vector3(transform.rotation.x, 16, transform.rotation.z), 0.2f).OnComplete(() =>
        {
            transform.DORotate(new Vector3(transform.rotation.x, -15, transform.rotation.z), 0.2f);
        });
    }

    public void MovePlayerRight()
    {
        if (playerIsRightSide) { return; }

        playerIsRightSide = true;
        playerIsLeftSide = false;

        transform.DOMoveX(playerRightPos.position.x, playerSideToSideSpeed);
        transform.DORotate(new Vector3(transform.rotation.x, -44, transform.rotation.z), 0.2f).OnComplete(() =>
        {
            transform.DORotate(new Vector3(transform.rotation.x, -15, transform.rotation.z), 0.2f);
        });
    }

    private void FlyUpwardsForce()
    {
        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {

        yield return new WaitForSeconds(gameStartDelay);

        transform.DOMoveY(endGamePoint.position.y, miniGamePlayTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameIsEnded.Raise();
        });

        yield return null;

    }
}
