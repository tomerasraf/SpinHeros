using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoosePlayerLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Events")]
    [SerializeField] VoidEvent shark;
    [SerializeField] VoidEvent joker;
    [SerializeField] VoidEvent kraken;
    [SerializeField] VoidEvent replace;
    [SerializeField] VoidEvent endOfChoice;

    private bool playerIsChoosing = true;

    public void StartPlayerChoiceCourotine()
    {
        playerIsChoosing = true;
        StartCoroutine(ChoosePlayerCourotine());
    }

    IEnumerator ChoosePlayerCourotine()
    {
        Debug.Log("Nice");
        while (playerIsChoosing)
        {
            if (Input.touchCount > 0)
            {
                // Geting the position of the finger on the screen.
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
                Vector3 touchPosNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
                Vector3 touchPosF = Camera.main.ScreenToWorldPoint(touchPosFar);
                Vector3 touchPosN = Camera.main.ScreenToWorldPoint(touchPosNear);

                RaycastHit hit;

                // Shooting a ray from the camera to the world
                if (Physics.Raycast(touchPosN, touchPosF - touchPosN, out hit))
                {
                    if (hit.transform.name == "Player_2" ||
                     hit.transform.name == "Player_3" ||
                      hit.transform.name == "Player_4" &&
                       hit.transform.name != "Player_1")
                    {
                        CheckWheelResultAfterChoosing();
                        playerIsChoosing = false;
                        endOfChoice.Raise();
                    }
                }

            }
            yield return null;
        }
        yield return null;
    }

    public void CheckWheelResultAfterChoosing()
    {
        switch (_spiningWheelData.results[0])
        {
            case 0:
                replace.Raise();
                Debug.Log("Replace");
                break;
            case 1:
                shark.Raise();
                Debug.Log("shark");
                break;
            case 2:
                joker.Raise();
                Debug.Log("joker");
                break;
            case 6:
                kraken.Raise();
                Debug.Log("kraken");
                break;
        }
    }

}