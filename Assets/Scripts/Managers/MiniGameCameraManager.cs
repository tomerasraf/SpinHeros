using UnityEngine;
using System.Collections;

public class MiniGameCameraManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] GameObject[] Players_Cam;
    [SerializeField] GameObject Game_Cam;

    [Header("Vars")]

    [SerializeField] float dealyStart;
    [SerializeField] float dealyEnableUI;

    [Header("Events")]
    [SerializeField] VoidEvent DisplayUI_On;


    private void Start()
    {
        StartCoroutine(StartCamera());
    }

    IEnumerator StartCamera()
    {
        yield return new WaitForSeconds(dealyStart);

        Game_Cam.SetActive(enabled);

        yield return new WaitForSeconds(dealyEnableUI);
        Players_Cam[0].SetActive(false);
        DisplayUI_On.Raise();

        yield return null;
    }

    public void FocusOnTheWinner(int PlayerID) {
        Players_Cam[PlayerID].SetActive(true);        
    }

}