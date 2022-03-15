
using UnityEngine;

public class SpinInput : MonoBehaviour
{
    [SerializeField] private VoidEvent SpinButtonPressed;

    public void SpinInputEventCall()
    {
        SpinButtonPressed.Raise();
    }
}
