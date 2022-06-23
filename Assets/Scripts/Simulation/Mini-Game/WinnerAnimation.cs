using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Simulation.Mini_Game
{
    public class WinnerAnimation : MonoBehaviour
    {
        [SerializeField] Animator[] playersAnimators;
        [Header("Events")]
        [SerializeField] VoidEvent miniGameIsOver;

        [Header("Effects")]
        [SerializeField] GameObject fireWorksEffect;

        public void PlayWinnerAnimation(int playerID) {

            StartCoroutine(playerWon_Coroutine(playerID));
        }


        IEnumerator playerWon_Coroutine(int playerID) {

            playersAnimators[playerID].SetBool("PlayerWon", true);

            Instantiate(fireWorksEffect, playersAnimators[playerID].transform.position + Vector3.up * 2, Quaternion.identity);  

            yield return new WaitForSeconds(5f);

            miniGameIsOver.Raise();

            yield return null;
        }
    }
}