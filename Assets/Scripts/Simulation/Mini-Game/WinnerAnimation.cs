using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Simulation.Mini_Game
{
    public class WinnerAnimation : MonoBehaviour
    {
        [SerializeField] Animator[] playersAnimators;

        public void PlayWinnerAnimation(int playerID) {

            playersAnimators[playerID].SetBool("PlayerWon", true);

        }
    }
}