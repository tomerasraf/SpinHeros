using UnityEngine;
using System.Collections;

public class CoinEffect : MonoBehaviour
{
    [SerializeField] GameObject goldCoinEffect;

    private void Start()
    {
        goldCoinEffect.SetActive(false);
    }

    public void goldCoinEffect_Listener()
    {
        StartCoroutine(goldCoinEffect_Coroutine());
    }

    IEnumerator goldCoinEffect_Coroutine()
    {
        goldCoinEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        goldCoinEffect.SetActive(false);
        yield return null;
    }
}