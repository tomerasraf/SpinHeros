using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Shark : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData[] _playerData;
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Prefabs")]
    [SerializeField] GameObject sharkPrefab;
    [SerializeField] GameObject[] stunEffects;

    [Header("DOTweenPhats")]
    [SerializeField] DOTweenPath[] paths;

    [Header("Players Animators")]
    [SerializeField] Animator[] playersAnimator;

    [Header("Spin Button")]
    [SerializeField] Button spinButton;

    private GameObject cloneShark;
    private GameObject AIcloneShark;

    private float animDuration = 1.5f;

    public void PlayerSharkAnimation_Listener()
    {
        StartCoroutine(PlayerSharkAnimation());
    }

    public void AISharkAnimation_Listener(int id)
    {
        StartCoroutine(AISharkAnimation(id));
    }

    IEnumerator PlayerSharkAnimation()
    {
        paths[_spiningWheelData.choosenPlayer].DORewind();
        playersAnimator[0].SetBool("isSpining", true);
        PlayerSpawnShark();
        paths[_spiningWheelData.choosenPlayer].DOPlay();

        yield return new WaitForSeconds(animDuration);

        paths[_spiningWheelData.choosenPlayer].DORewind();
        Destroy(cloneShark);
        StartCoroutine(playerGotHitEffect());
        playersAnimator[_spiningWheelData.choosenPlayer].SetBool("gotHit", true);

        playersAnimator[0].SetBool("isSpining", false);
        yield return null;
    }

    IEnumerator AISharkAnimation(int id)
    {
        paths[_spiningWheelData.AIChoosenPlayer].DORewind();
        playersAnimator[id].SetBool("isSpining", true);
        AISpawnShark();
        paths[_spiningWheelData.AIChoosenPlayer].DOPlay();

        yield return new WaitForSeconds(animDuration);

        paths[_spiningWheelData.AIChoosenPlayer].DORewind();
        Destroy(AIcloneShark);
        StartCoroutine(AIGotHitEffect());
        playersAnimator[_spiningWheelData.AIChoosenPlayer].SetBool("gotHit", true);

        playersAnimator[id].SetBool("isSpining", false);
        yield return null;
    }

    private void PlayerSpawnShark()
    {
        cloneShark = Instantiate(sharkPrefab, paths[_spiningWheelData.choosenPlayer].transform.position, Quaternion.identity);
        cloneShark.transform.parent = paths[_spiningWheelData.choosenPlayer].transform;
    }

    private void AISpawnShark()
    {
        AIcloneShark = Instantiate(sharkPrefab, paths[_spiningWheelData.AIChoosenPlayer].transform.position, Quaternion.identity);
        AIcloneShark.transform.parent = paths[_spiningWheelData.AIChoosenPlayer].transform;
    }


    IEnumerator playerGotHitEffect()
    {
        stunEffects[_spiningWheelData.choosenPlayer].transform.DOScale(0, 0f);
        stunEffects[_spiningWheelData.choosenPlayer].SetActive(true);
        stunEffects[_spiningWheelData.choosenPlayer].transform.DOScale(1, 1f);

        yield return new WaitForSeconds(2f);

        if (_playerData[_spiningWheelData.choosenPlayer].playerIsDead)
        {
            _spiningWheelData.choosenPlayer = 0;
            yield return null;
        }

        playersAnimator[_spiningWheelData.choosenPlayer].SetBool("gotHit", false);
        stunEffects[_spiningWheelData.choosenPlayer].transform.DOScale(0, 1f).OnComplete(() =>
        {
            stunEffects[_spiningWheelData.choosenPlayer].SetActive(false);
            _spiningWheelData.choosenPlayer = 0;
        });

        yield return null;
    }

    IEnumerator AIGotHitEffect()
    {
        if (_spiningWheelData.AIChoosenPlayer == 0)
        {
            spinButton.enabled = false;
        }

        stunEffects[_spiningWheelData.AIChoosenPlayer].transform.DOScale(0, 0f);
        stunEffects[_spiningWheelData.AIChoosenPlayer].SetActive(true);
        stunEffects[_spiningWheelData.AIChoosenPlayer].transform.DOScale(1, 1f);

        

        yield return new WaitForSeconds(2f);


        if (_playerData[_spiningWheelData.AIChoosenPlayer].playerIsDead)
        {
            _spiningWheelData.AIChoosenPlayer = 0;
            yield return null;
        }

        playersAnimator[_spiningWheelData.AIChoosenPlayer].SetBool("gotHit", false);
        stunEffects[_spiningWheelData.AIChoosenPlayer].transform.DOScale(0, 1f).OnComplete(() =>
        {
            stunEffects[_spiningWheelData.AIChoosenPlayer].SetActive(false);

            if (_spiningWheelData.AIChoosenPlayer == 0)
            {
                spinButton.enabled = true;
            }

            _spiningWheelData.AIChoosenPlayer = 0;
        });

        yield return null;
    }
}