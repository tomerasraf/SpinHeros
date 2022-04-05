using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] Animator[] players;
    [SerializeField] GameObject fishPrefab;

    public void ThrowAnim()
    {
        foreach (Animator player in players)
        {
            player.SetBool("isSpining", true);
        }
    }

    public void StopThrowAnim()
    {
        foreach (Animator player in players)
        {
            player.SetBool("isSpining", false);
        }
    }

}