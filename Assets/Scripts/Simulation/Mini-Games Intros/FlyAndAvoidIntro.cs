using DG.Tweening;
using System.Collections;
using UnityEngine;

public class FlyAndAvoidIntro : MonoBehaviour
{
    [Header("Prefabs & GameObjects")]
    [SerializeField] GameObject[] meteorPrefabs;
    [SerializeField] GameObject[] spawnPositions;
    public GameObject meteorCopy;

    [Header("Cameras")]
    [SerializeField] GameObject buildCam;
    [SerializeField] GameObject wheelCam;

    [Header("Player")]
    [SerializeField] GameObject player;

    public void flyAndAvoidIntro_Listener()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        yield return StartCoroutine(CameraShake());
        yield return StartCoroutine(CameraFocusOnTheVillage());
        yield return StartCoroutine(MeteorShower());
        yield return StartCoroutine(CameraFocusOnThePlayer());

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
        wheelCam.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        buildCam.SetActive(false);
        yield return null;
    }

    IEnumerator CameraShake()
    {
        yield return new WaitForSeconds(1);
        wheelCam.transform.DOShakeRotation(3.5f, 5f, 10, 90);
        yield return new WaitForSeconds(3.5f);
        yield return null;
    }

    IEnumerator MeteorShower()
    {
        for (int i = 0; i < 5; i++)
        {
            meteorCopy = Instantiate(
                   meteorPrefabs[Random.Range(0, 10)],
                   spawnPositions[Random.Range(0, 8)].transform.position + Vector3.up * 28,
                   Quaternion.identity);

            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(3);
        yield return null;
    }




}
