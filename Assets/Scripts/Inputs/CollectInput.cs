using UnityEngine;

public class CollectInput : MonoBehaviour
{
    [SerializeField] VoidEvent collectButtonPress_Event;

    public void CollectButton_Listener()
    {
        collectButtonPress_Event.Raise();
    }
}