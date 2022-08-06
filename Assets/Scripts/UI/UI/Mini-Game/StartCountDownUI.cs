using UnityEngine;
using System.Collections;
using TMPro;

public class StartCountDownUI : MonoBehaviour
{
    [SerializeField] GameObject startCountDown_Image;
    [SerializeField] TextMeshProUGUI countDownText;

    [Header("Events")]
    [SerializeField] VoidEvent miniGameIsStarted;
 
    private void Start()
    {
        StartCoroutine(StratCountDown_Coroutine());
    }

    IEnumerator StratCountDown_Coroutine()
    {
        startCountDown_Image.SetActive(true);
        countDownText.text = "Ready!";

        yield return new WaitForSeconds(1);
           
        countDownText.text = "Set!";

        yield return new WaitForSeconds(1);

        countDownText.text = "Go!";

        yield return new WaitForSeconds(1);

        startCountDown_Image.SetActive(false);
        
        yield return new WaitForSeconds(0.6f);
        miniGameIsStarted.Raise();

        yield return null;
    }

}