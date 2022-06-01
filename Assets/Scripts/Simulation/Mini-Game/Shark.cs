using DG.Tweening;
using System.Collections;
using UnityEngine;
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
    [SerializeField] Animator[] playersAnimator;

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
        playersAnimator[0].SetBool("isSpining", true);
        SpawnShark();
        paths[_spiningWheelData.choosenPlayer - 1].DOPlay();

        yield return new WaitForSeconds(animDuration);

        paths[_spiningWheelData.choosenPlayer - 1].DORewind();
        Destroy(cloneShark);
        StartCoroutine(playerGotHitEffect());
        playersAnimator[_spiningWheelData.choosenPlayer ].SetBool("gotHit", true);

        playersAnimator[0].SetBool("isSpining", false);
        yield return null;
    }


    IEnumerator playerGotHitEffect()
    {

        stunEffects[_spiningWheelData.choosenPlayer - 1].transform.DOScale(0, 0f);
        stunEffects[_spiningWheelData.choosenPlayer - 1].SetActive(true);
        stunEffects[_spiningWheelData.choosenPlayer - 1].transform.DOScale(1, 1f);

        yield return new WaitForSeconds(3f);

        stunEffects[_spiningWheelData.choosenPlayer - 1].transform.DOScale(0, 1f).OnComplete(() =>
        {
            stunEffects[_spiningWheelData.choosenPlayer - 1].SetActive(false);
            playersAnimator[_spiningWheelData.choosenPlayer ].SetBool("gotHit", false);
        });


        yield return null;
    }


}