using UnityEngine;
using System.Collections;
using TMPro;

public class StartCountDownUI : MonoBehaviour
{
    [SerializeField] GameObject startCountDown_Image;
    [SerializeField] TextMeshProUGUI countDownText;

    private float counter = 3.5f;

    private void Start()
    {
        StartCoroutine(StratCountDown_Coroutine());
    }

    IEnumerator StratCountDown_Coroutine()
    {
        startCountDown_Image.SetActive(true);
        while (counter > 0)
        {
            counter -= Time.deltaTime;
            int counterInt = (int)counter;
            countDownText.text = counterInt.ToString();

            yield return null;
        }

        countDownText.text = "Go!";

        startCountDown_Image.SetActive(false);

        yield return null;
    }

}