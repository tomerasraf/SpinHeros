using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    //1. Detect Player touch the screen.
    //2. Store this postion as the origin.
    //3. Store the current position of the touch.
    //4. calculate the diffrence bettwen the origin to the curent postion of the touch.
    //5. move the position of the camera to diffrence.
    [Header("Data")]
    [SerializeField] GameSettingsData _gameSettingsData;
    [SerializeField] SystemData _systemData;
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] WorldData _worldData;

    [Header("Cameras")]
    [SerializeField] GameObject wheelCamera;
    [SerializeField] GameObject worldCamera;
    [SerializeField] GameObject cinemachine;
    [SerializeField] GameObject buildCamera;
    [SerializeField] GameObject heroCamera;

    [Header("Camera Look at Target")]
    [SerializeField] GameObject cameraTarget;

    [Header("Main Camera Vars")]
    [SerializeField] float cameraSensitivity;
    [SerializeField] float smoothSpeed;
    [SerializeField] float minLimitedValue = -22.875f;
    [SerializeField] float maxLimitedValue = 17.875f;

    [Header("Effects")]
    [SerializeField] GameObject lightningEffect;
    [SerializeField] GameObject whirlWind;
    [SerializeField] GameObject burnedHouse;
    [SerializeField] GameObject cutsceneHouse;

    [Header("Hero")]
    [SerializeField] GameObject hero;

    [Header("Events")]
    [SerializeField] VoidEvent lightningHit;
    [SerializeField] VoidEvent heroIsLowering;
    [SerializeField] VoidEvent heroblowingAir;
    [SerializeField] VoidEvent heroLiftOff;
    [SerializeField] VoidEvent turnOffUI;
    [SerializeField] VoidEvent turnOnUI;
    [SerializeField] VoidEvent clickMeEvent;
    [SerializeField] VoidEvent removeClickMe;
    [SerializeField] VoidEvent buildUITutorial;

   private int whirlWindCounter = 0;

    private Vector3 EndTouchPosition;


    private void Start()
    {
        if (_miniGameData.wasInMiniGame)
        {
            wheelCamera.SetActive(true);
            _miniGameData.wasInMiniGame = false;
        }
        else
        {
            worldCamera.SetActive(true);
        }

        if (_gameSettingsData.tutorialMode)
        {
            turnOffUI.Raise();
            wheelCamera.SetActive(false);
            cutsceneHouse.SetActive(true);
            worldCamera.SetActive(true);
            StartCoroutine(firstCutScene());
        }
        else
        {

        }
    }

    IEnumerator firstCutScene()
    {
        _worldData.buildingIsSaved = false;

        worldCamera.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        heroCamera.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        lightningEffect.SetActive(true);
        lightningHit.Raise();

        yield return new WaitForSeconds(1);

        heroIsLowering.Raise();

        hero.transform.DOMoveY(hero.transform.position.y - 18, 2.3f).OnComplete(() => {
            hero.transform.DOMoveY(hero.transform.position.y + 0.5f, 2f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.OutSine);
            turnOnUI.Raise();
            clickMeEvent.Raise();
        });

        while (!_worldData.buildingIsSaved) {

            if (TouchInput.TouchScreenDetector()) {
                heroblowingAir.Raise();
                whirlWind.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                whirlWind.SetActive(false);
                whirlWindCounter++;

                if (whirlWindCounter >= 3) {
                    _worldData.buildingIsSaved = true;
                }
            }
            yield return null;
        }

        removeClickMe.Raise();
        burnedHouse.SetActive(true);
        cutsceneHouse.SetActive(false);

        yield return new WaitForSeconds(2.1f);

        heroLiftOff.Raise();
        hero.transform.DOMoveY(hero.transform.position.y - 1, 1f).OnComplete(() => {
             hero.transform.DOMoveY(hero.transform.position.y + 30, 1f).OnComplete(() => {
               
                hero.SetActive(false);
                buildUITutorial.Raise();
             });
        });

        turnOnUI.Raise();

        yield return null;
    }

    private void LateUpdate()
    {
        if (cinemachine.transform.position == wheelCamera.transform.position)
        {
            _systemData.cameraIsFocusedOnWheel = true;
        }
        else
        {
            _systemData.cameraIsFocusedOnWheel = false;
        }

        if (_worldData.buldingModeIsOn || _systemData.inMenu || _gameSettingsData.tutorialMode) { return; }
        EndTouchPosition = TouchInput.DetectTouchInput(minLimitedValue, maxLimitedValue);
        worldCamera.transform.LookAt(cameraTarget.transform);
        MoveCamera();
    }

    public void CameraFocus_ToWheel()
    {
        buildCamera.SetActive(false);
        wheelCamera.SetActive(true);
        worldCamera.SetActive(false);
    }
    public void CameraFocus_ToWorld()
    {
        buildCamera.SetActive(false);
        wheelCamera.SetActive(false);
        worldCamera.SetActive(true);
    }

    public void CameraFocus_BuildMode()
    {
        wheelCamera.SetActive(false);
        worldCamera.SetActive(false);
        buildCamera.SetActive(true);
    }

    private void MoveCamera()
    {
        Vector3 smoothedPosition = Vector3.Lerp(worldCamera.transform.position, EndTouchPosition, smoothSpeed);

        Vector3 newCameraPosition = new Vector3(smoothedPosition.x * cameraSensitivity * Time.fixedDeltaTime,
        worldCamera.transform.position.y,
        worldCamera.transform.position.z);
        worldCamera.transform.position = newCameraPosition;
    }
}