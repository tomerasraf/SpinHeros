using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private VoidEvent TimerIsEnded;
    [SerializeField] float duration;
    private float counter = 0f;


    public void StartCountDown()
    {
        StartCoroutine(CountDown(duration, counter));
    }

    IEnumerator CountDown(float duration, float counter)
    {
        counter = duration;
        yield return new WaitForSeconds(counter);
        TimerIsEnded.Raise();

    }
}