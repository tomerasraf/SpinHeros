using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameAI : MonoBehaviour
{

    [Header("Data")]
    [SerializeField] PlayerData[] _playersData;
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Events")]
    [SerializeField] IntEvent AIAutoSpin_ID;
    [SerializeField] IntEvent AISharkAnimation_ID;
    [SerializeField] VoidEvent ScoreUI_Updater;

    [Header("Counter Max & Min values")]
    [SerializeField] float minCounter;
    [SerializeField] float maxCounter;

    public void MiniGameStart_Listener() {

        StartCoroutine(AIAutoSpin());
    }

    public void AIAutoAttackCoroutine_Listener(int id) {
        StartCoroutine(AIAutoAttack(id));
    }

    IEnumerator AIAutoSpin() {

        while (!_miniGameData.gameIsOver) {
            float randCounter = Random.Range(minCounter, maxCounter);

            yield return new WaitForSeconds(randCounter);

                int randSymbol = 0;
                randSymbol = Random.Range(0, 100);
      
                float IDRand = Random.Range(1, 4);
                _spiningWheelData.results[(int)IDRand] = _spiningWheelData.wheelsSlots[randSymbol];

            if (_spiningWheelData.choosenPlayer == IDRand || _spiningWheelData.AIChoosenPlayer == IDRand)
            {
               yield return null;
            }
            else {
                AIAutoSpin_ID.Raise((int)IDRand);
            }
            

            yield return null;
        }
       
        yield return null;
    }

    IEnumerator AIAutoAttack(int id) {

        // prevent the AI from attacking itself.
        int rand = Random.Range(0, 4);
        while (rand == id) {
            rand = Random.Range(0, 4);
        }

        _spiningWheelData.AIChoosenPlayer = rand;
        AISharkAnimation_ID.Raise(id);
        AIAttackChoosenPlayer();
        yield return null;
    }

    private void AIAttackChoosenPlayer() {
        _playersData[_spiningWheelData.AIChoosenPlayer].hearts--;
        ScoreUI_Updater.Raise();
    }
 
}
