using DG.Tweening;
using System.Collections;
using UnityEngine;

public class FlyAndAvoidIntro : MonoBehaviour
{
    [Header("Prefabs & GameObjects")]
    [SerializeField] GameObject[] meteorPrefabs;
    [SerializeField] GameObject[] spawnPositions;
    [SerializeField] Transform playerIntroPosition;
    public GameObject meteorCopy;

    [Header("Data")]
    [SerializeField] SlotMachineData _slotMachineData;

    [Header("Cameras")]
    [SerializeField] GameObject buildCam;
    [SerializeField] GameObject wheelCam;
    [SerializeField] GameObject playerCam;

    [Header("UI")]
    [SerializeField] GameObject playerDialog;

    [Header("Player")]
    [SerializeField] GameObject player;

    [Header("Events")]
    [SerializeField] VoidEvent pullbackUIAnimation;
    [SerializeField] IntEvent loadMiniGame;


    public void flyAndAvoidIntro_Listener()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        pullbackUIAnimation.Raise();

        yield return StartCoroutine(CameraFocusOnTheVillage());
        yield return StartCoroutine(MeteorShower());

        player.transform.position = playerIntroPosition.position;
        player.transform.rotation = Quaternion.Euler(0, -180, 0);
        player.transform.DOMoveY(player.transform.position.y + 0.5f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutSine);

        yield return StartCoroutine(CameraFocusOnThePlayer());
        yield return StartCoroutine(PlayerDialog());
        yield return StartCoroutine(PlayerFlyAway());

        loadMiniGame.Raise(_slotMachineData.currentMiniGame);

        yield return null;
    }

    IEnumerator PlayerDialog()
    {
        bool screenAsClicked = false;
        yield return new WaitForSeconds(2);
        TutorialAnimationUtils.MassagePopoutAnimation(playerDialog.transform.localScale, playerDialog, 1);

        while (!screenAsClicked)
        {
            if (TouchInput.TouchScreenDetector())
            {
                screenAsClicked = true;
                player.transform.DOKill();
            }
            yield return null;
        }

        TutorialAnimationUtils.RemoveMassageAnimation(playerDialog, 0.5f);
        yield return null;
    }

    IEnumerator PlayerFlyAway()
    {
        player.transform.DOMoveY(player.transform.position.y - 1, 1f).OnComplete(() =>
        {
            player.transform.DOMoveY(player.transform.position.y + 30, 1f);
        });

        yield return null;
    }

    IEnumerator CameraFocusOnTheVillage()
    {
        buildCam.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        wheelCam.SetActive(false);
        yield return null;
    }
    IEnumerator CameraFocusOnThePlayer()
    {
        playerCam.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        buildCam.SetActive(false);
        yield return null;
    }

    IEnumerator CameraShake()
    {
        yield return new WaitForSeconds(1);
        buildCam.transform.DOShakeRotation(3.5f, 5f, 10, 90);
        yield return null;
    }

    IEnumerator MeteorShower()
    {
        for (int i = 0; i < 5; i++)
        {
            meteorCopy = Instantiate(
                   meteorPrefabs[Random.Range(0, 10)],
                   spawnPositions[Random.Range(0, 8)].transform.position + Vector3.up * 28,
                   Quaternion.identity
                   );

            yield return new WaitForSeconds(0.3f);
        }
        StartCoroutine(CameraShake());

        yield return new WaitForSeconds(3);
        yield return null;
    }
}
