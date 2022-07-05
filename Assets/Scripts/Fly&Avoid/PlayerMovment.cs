using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float playerGetsToPositionTime;

    [SerializeField] Transform PlayerLeftPos;
    [SerializeField] Transform PlayerRightPos;
    private Vector3 playerStartPos;

    private bool playerIsLeftSide = false;
    private bool playerIsRightSide = false;

    private void Start()
    {
        playerStartPos = transform.position;
    }

    public void MovePlayerLeft() {
        if (playerIsLeftSide) { return; }

        playerIsLeftSide = true;
        playerIsRightSide = false;

        transform.DOMoveX(PlayerLeftPos.position.x, playerGetsToPositionTime);
        transform.DORotate(new Vector3(transform.rotation.x, 16, transform.rotation.z), 0.2f).OnComplete(() =>
        {
            transform.DORotate(new Vector3(transform.rotation.x, -15, transform.rotation.z), 0.2f);
        });
    }

    public void MovePlayerRight() {
        if (playerIsRightSide) { return; }

        playerIsRightSide = true;
        playerIsLeftSide = false;

        transform.DOMoveX(PlayerRightPos.position.x, playerGetsToPositionTime);
        transform.DORotate(new Vector3(transform.rotation.x, -44, transform.rotation.z), 0.2f).OnComplete(() =>
        {
            transform.DORotate(new Vector3(transform.rotation.x, -15, transform.rotation.z), 0.2f);
        });
    }
}
