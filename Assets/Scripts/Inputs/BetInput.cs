using UnityEngine;

public class BetInput : MonoBehaviour
{
    [SerializeField] private VoidEvent BetButtonPressed;
    public void BetButtonEventCall()
    {
        BetButtonPressed.Raise();
    }
}