using System.Collections;
using UnityEngine;

public class SpotLightEffect : MonoBehaviour
{

    [SerializeField] GameObject spotLightEffect_Object;

    public void spotLightEffect_listener()
    {
        StartCoroutine(spotlightEffect_Coroutine());
    }

    IEnumerator spotlightEffect_Coroutine()
    {

        spotLightEffect_Object.SetActive(true);

        yield return new WaitForSeconds(4f);

        spotLightEffect_Object.SetActive(false);

        yield return null;

    }
}
