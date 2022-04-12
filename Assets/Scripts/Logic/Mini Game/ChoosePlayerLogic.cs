using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoosePlayerLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData[] _playersData;
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Events")]
    [SerializeField] VoidEvent shark;
    [SerializeField] VoidEvent endOfChoice;

    private bool playerIsChoosing = true;

    public void StartPlayerChoiceCourotine()
    {
        playerIsChoosing = true;
        StartCoroutine(ChoosePlayerCourotine());
    }

    IEnumerator ChoosePlayerCourotine()
    {

        while (playerIsChoosing)
        {
            ChoosePlayer();
            yield return null;
        }
        yield return null;
    }

    private void ChoosePlayer()
    {
        if (Input.touchCount > 0)
        {

            // Geting the position of the finger on the screen.
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
            Vector3 touchPosNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
            Vector3 touchPosF = Camera.main.ScreenToWorldPoint(touchPosFar);
            Vector3 touchPosN = Camera.main.ScreenToWorldPoint(touchPosNear);

            // Info about the hit object.
            RaycastHit hit;

            // Shooting a ray from the camera to the desire player.
            if (Physics.Raycast(touchPosN, touchPosF - touchPosN, out hit))
            {
                SelectPlayer(hit);
            }
        }
    }

    private void SelectPlayer(RaycastHit hit)
    {

        if (hit.transform.name == "Player_2")
        {
            _spiningWheelData.choosenPlayer = 0;
            shark.Raise();
            attackChoosenPlayer();
            playerIsChoosing = false;
            endOfChoice.Raise();
        }
        if (hit.transform.name == "Player_3")
        {
            _spiningWheelData.choosenPlayer = 1;
            shark.Raise();
            attackChoosenPlayer();
            playerIsChoosing = false;
            endOfChoice.Raise();
        }
        if (hit.transform.name == "Player_4")
        {
            _spiningWheelData.choosenPlayer = 2;
            shark.Raise();
            attackChoosenPlayer();
            playerIsChoosing = false;
            endOfChoice.Raise();
        }
    }

    public void attackChoosenPlayer()
    {
        // Shark attack
        _playersData[_spiningWheelData.choosenPlayer].hearts--;
    }
}