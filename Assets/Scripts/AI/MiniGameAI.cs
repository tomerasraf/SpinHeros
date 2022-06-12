using System.Collections;
using UnityEngine;

public class MiniGameAI : MonoBehaviour
{

    [Header("Data")]
    [SerializeField] PlayerData[] _playersData;
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Events")]
    [SerializeField] IntEvent CheckPrizeAI_ID;
    [SerializeField] IntEvent AISharkAnimation_ID;
    [SerializeField] VoidEvent ScoreUI_Updater;
    [SerializeField] IntEvent PlayerIsDead_ID;

    [Header("Counter Max & Min values")]
    [SerializeField] float minCounter;
    [SerializeField] float maxCounter;

    public void MiniGameStart_Listener()
    {

        StartCoroutine(AIAutoSpin());
    }

    public void AIAutoAttackCoroutine_Listener(int id)
    {
        StartCoroutine(AIAutoAttack(id));
    }

    IEnumerator AIAutoSpin()
    {

        while (!_miniGameData.gameIsOver)
        {
            float randCounter = Random.Range(minCounter, maxCounter);

            yield return new WaitForSeconds(randCounter);

            int randSymbol = 0;
            randSymbol = Random.Range(0, 100);

            int IDRand = Random.Range(1, 4);
            while (_playersData[IDRand].playerIsDead)
            {
                if(_miniGameData.playerAlive == 1)
                {
                    break;
                }
                IDRand = Random.Range(1, 4);
            }

            _spiningWheelData.results[IDRand] = _spiningWheelData.wheelsSlots[randSymbol];

            if (_spiningWheelData.choosenPlayer == IDRand || _spiningWheelData.AIChoosenPlayer == IDRand)
            {
                yield return null;
            }
            else if (_playersData[IDRand].playerIsDead)
            {

                PlayerIsDead_ID.Raise(IDRand);
                yield return null;
            }
            else
            {
                CheckPrizeAI_ID.Raise(IDRand);
            }


            yield return null;
        }

        yield return null;
    }

    IEnumerator AIAutoAttack(int id)
    {
        

         
            // prevent the AI from attacking itself and dead players.
            int randPlayerToAttack = Random.Range(0, 4);
        while (randPlayerToAttack == id || _playersData[randPlayerToAttack].playerIsDead)
        {
            if (_miniGameData.playerAlive == 1)
            {
                break;
            }
            randPlayerToAttack = Random.Range(0, 4);
        }

        if (_miniGameData.playerAlive == 1) {
            yield return null;
        }

        _spiningWheelData.AIChoosenPlayer = randPlayerToAttack;
        AISharkAnimation_ID.Raise(id);
        AIAttackChoosenPlayer();
        yield return null;
    }

    private void AIAttackChoosenPlayer()
    {
        _playersData[_spiningWheelData.AIChoosenPlayer].hearts--;
        ScoreUI_Updater.Raise();
    }

}
