using UnityEngine;
using System.Collections;

public class MiniGameCameraManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;

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

        camera2.SetActive(enabled);

        yield return new WaitForSeconds(dealyEnableUI);
        DisplayUI_On.Raise();

        yield return null;
    }

}