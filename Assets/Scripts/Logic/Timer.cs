using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private VoidEvent TimerIsEnded;
    private float counter = 0f;


    public void StartCountDown()
    {
        StartCoroutine(CountDown(counter));
    }

    IEnumerator CountDown(float counter)
    {
        float rand = Random.Range(0.5f, 1f);
        counter = rand;
        yield return new WaitForSeconds(counter);
        TimerIsEnded.Raise();

    }
}