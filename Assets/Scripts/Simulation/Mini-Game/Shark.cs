using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Shark : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Prefabs")]
    [SerializeField] GameObject sharkPrefab;
    [SerializeField] GameObject[] stunEffects;

    [Header("DOTweenPhats")]
    [SerializeField] DOTweenPath[] paths;

    [Header("Players Animators")]
    [SerializeField] Animator[] players;

    private GameObject cloneShark;

    private float animDuration = 1.5f;

    public void SharkSimoultaion()
    {
        StartCoroutine(SimoulationCoroutine());
    }

    private void SpawnShark()
    {
        cloneShark = Instantiate(sharkPrefab, paths[_spiningWheelData.choosenPlayer - 1].transform.position, Quaternion.identity);
        cloneShark.transform.parent = paths[_spiningWheelData.choosenPlayer - 1].transform;
    }

    IEnumerator SimoulationCoroutine()
    {
        players[0].SetBool("isSpining", true);
        SpawnShark();
        paths[_spiningWheelData.choosenPlayer - 1].DOPlay();

        yield return new WaitForSeconds(animDuration);

        paths[_spiningWheelData.choosenPlayer - 1].DORewind();
        Destroy(cloneShark);
        playerGotHitEffect();

        players[0].SetBool("isSpining", false);
        yield return null;
    }


    private void playerGotHitEffect() {

        stunEffects[_spiningWheelData.choosenPlayer - 1].SetActive(true);

    }


}