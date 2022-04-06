using UnityEngine;

public class RodAnimation : MonoBehaviour
{
    [SerializeField] Animator[] players;

    public void CatchAnim()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetBool("isSpining", true);
        }
    }

    public void IdleAnim()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetBool("isSpining", false);
        }
    }
}