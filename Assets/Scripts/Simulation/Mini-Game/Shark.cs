using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Shark : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Prefabs")]
    [SerializeField] GameObject sharkPrefab;

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
        cloneShark = Instantiate(sharkPrefab, paths[_spiningWheelData.choosenPlayer].transform.position, Quaternion.identity);
        cloneShark.transform.parent = paths[_spiningWheelData.choosenPlayer].transform;
    }

    IEnumerator SimoulationCoroutine()
    {
        players[0].SetBool("isSpining", true);
        SpawnShark();
        paths[_spiningWheelData.choosenPlayer].DOPlay();

        yield return new WaitForSeconds(animDuration);

        paths[_spiningWheelData.choosenPlayer].DORewind();
        Destroy(cloneShark);

        players[0].SetBool("isSpining", false);
        yield return null;
    }


}