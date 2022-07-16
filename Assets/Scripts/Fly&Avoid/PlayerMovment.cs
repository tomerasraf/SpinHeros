using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData _playerData;
    [SerializeField] FlyAndAvoidData _flyAndAvoidData;

    [Header("Vars")]
    [SerializeField] float playerFlightSpeed;
    
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
    [SerializeField] VoidEvent windSFX;
    [SerializeField] VoidEvent SideToSideSound;

    private bool playerIsLeftSide = false;
    private bool playerIsRightSide = false;

    private void Start()
    {
        FlyUpwardsForce();
    }

    public void MovePlayerLeft()
    {
        if (playerIsLeftSide) { return; }

        SideToSideSound.Raise();
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

        SideToSideSound.Raise();
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

        windSFX.Raise();
        while ( _flyAndAvoidData.miniGamePlayTime > 0 )
        {
            if (_playerData.playerIsDead) { _flyAndAvoidData.miniGamePlayTime = 0; }

            Vector3 playerFlyingDiraction = new Vector3(
                transform.position.x,
                transform.position.y + playerFlightSpeed * Time.deltaTime,
                transform.position.z
                );

            transform.position = playerFlyingDiraction;

            _flyAndAvoidData.miniGamePlayTime -= Time.deltaTime;

            yield return null;
        }

        _flyAndAvoidData.gameIsEnded = true;
        gameIsEnded.Raise();

        yield return null;
    }
}
