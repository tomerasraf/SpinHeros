using UnityEngine;
using TMPro;
using System.Collections;
using DG.Tweening;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] PlayerData _playerData;
    [SerializeField] float smoothVelocity;
    [SerializeField] float smoothSpeed;
    private float displayCoins = 0;


    public void GainCoinUI_Updater()
    {
        StartCoroutine(GainCoinUI_Coroutine());
    }

    public void SpendCoinUI_Updater()
    {

        StartCoroutine(SpendCoinUI_Coroutine());
    }

    IEnumerator GainCoinUI_Coroutine()
    {
        while (displayCoins < _playerData.coins)
        {
            displayCoins = displayCoins + smoothVelocity * smoothSpeed;
            coinText.text = displayCoins.ToString();
            yield return null;
        }
        yield return null;
    }

    IEnumerator SpendCoinUI_Coroutine()
    {
        while (displayCoins > _playerData.coins)
        {
            displayCoins = displayCoins - smoothVelocity * smoothSpeed;
            coinText.text = displayCoins.ToString();
            yield return null;
        }
        yield return null;
    }


}