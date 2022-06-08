using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameAI : MonoBehaviour
{


    // 1. Create a random counter bettween 1.9 to 2.5 with Enumerator. 
    // 2. Every time the counter reach 0 AI should spin his wheel.

    [Header("Data")]
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Events")]
    [SerializeField] IntEvent AIAutoSpin_ID;

    [Header("Counter Max & Min values")]
    [SerializeField] float minCounter;
    [SerializeField] float maxCounter;

    public void MiniGameStart_Listener() {

        StartCoroutine(AIAutoSpin());
    }

    IEnumerator AIAutoSpin() {

        while (!_miniGameData.gameIsOver) {
            float randCounter = Random.Range(minCounter, maxCounter);

            yield return new WaitForSeconds(randCounter);

                int rand = 0;
                rand = Random.Range(0, 100);
      
                float IDRand = Random.Range(1, 4);
                _spiningWheelData.results[(int)IDRand] = _spiningWheelData.wheelsSlots[rand];
                AIAutoSpin_ID.Raise((int)IDRand);

       /*         float randDealyCounter = Random.Range(0.3f, 0.5f);
                yield return new WaitForSeconds(randDealyCounter);*/

            yield return null;
        }
       
        yield return null;
    }

    private void RamdomSpin()
    {
      
    }
}
