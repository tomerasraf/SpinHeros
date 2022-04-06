using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] Animator[] players;
    [SerializeField] GameObject fishPrefab;

    public void CatchFish_Anim(int playerID)
    {
        players[playerID].SetBool("isSpining", true);
    }

    public void Idel_Anim(int playerID)
    {
        players[playerID].SetBool("isSpining", false);
    }
}