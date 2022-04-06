using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] Animator[] players;
    [SerializeField] GameObject fishPrefab;

    public void ThrowAnim(int playerID)
    {
        players[playerID].SetBool("isSpining", true);
    }

    public void CatchAnim(int playerID)
    {
        players[playerID].SetBool("isSpining", false);
    }

}