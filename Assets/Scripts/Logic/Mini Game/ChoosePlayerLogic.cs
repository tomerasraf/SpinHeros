using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChoosePlayerLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData[] _playersData;
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Events")]
    [SerializeField] VoidEvent shark;
    [SerializeField] VoidEvent endOfChoice;

    [Header("Button")]
    [SerializeField] Button spinButton; 

    private bool playerIsChoosing = true;
    private float counter = 5;

    public void StartPlayerChoiceCourotine()
    {
        playerIsChoosing = true;
        StartCoroutine(ChoosePlayerCourotine());
    }

    IEnumerator ChoosePlayerCourotine()
    {
        while (playerIsChoosing)
        {
            spinButton.enabled = false;
            ChoosePlayer();
            yield return null;
        }
        yield return null;
    }

    private void ChoosePlayer()
    {

        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            spinButton.enabled = true;
            endOfChoice.Raise();
            playerIsChoosing = false;
            counter = 5;
        }


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
            _spiningWheelData.choosenPlayer = 1;
            shark.Raise();
            attackChoosenPlayer();
            playerIsChoosing = false;
            endOfChoice.Raise();
            spinButton.enabled = true;
            counter = 5;
        }
        if (hit.transform.name == "Player_3")
        {
            _spiningWheelData.choosenPlayer = 2;
            shark.Raise();
            attackChoosenPlayer();
            playerIsChoosing = false;
            endOfChoice.Raise();
            spinButton.enabled = true;
            counter = 5;
        }
        if (hit.transform.name == "Player_4")
        {
            _spiningWheelData.choosenPlayer = 3;
            shark.Raise();
            attackChoosenPlayer();
            playerIsChoosing = false;
            endOfChoice.Raise();
            spinButton.enabled = true;
            counter = 5;
        }
    }

    public void attackChoosenPlayer()
    {
        // Shark attack
        _playersData[_spiningWheelData.choosenPlayer].hearts--;
    }
}