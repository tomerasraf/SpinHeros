using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Simulation.Mini_Game
{
    public class WinnerAnimation : MonoBehaviour
    {
        [SerializeField] Animator[] playersAnimators;
        [Header("Events")]
        [SerializeField] VoidEvent miniGameIsOver;

        public void PlayWinnerAnimation(int playerID) {

            StartCoroutine(playerWon_Coroutine(playerID));
        }


        IEnumerator playerWon_Coroutine(int playerID) {

            playersAnimators[playerID].SetBool("PlayerWon", true);

            yield return new WaitForSeconds(5f);

            miniGameIsOver.Raise();

            yield return null;
        }
    }
}