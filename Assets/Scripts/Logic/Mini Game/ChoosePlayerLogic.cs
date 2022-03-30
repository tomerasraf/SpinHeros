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
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
                Vector3 touchPosNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
                Vector3 touchPosF = Camera.main.ScreenToWorldPoint(touchPosFar);
                Vector3 touchPosN = Camera.main.ScreenToWorldPoint(touchPosNear);

                RaycastHit hit;

                if (Physics.Raycast(touchPosN, touchPosF - touchPosN, out hit))
                {
                    if (hit.transform.name == "Player_" && hit.transform.name != "Player_1")
                    {
                        CheckWheelResultAfterChoosing();
                        playerIsChoosing = false;
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