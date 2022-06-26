using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotItInput : MonoBehaviour
{
    [SerializeField] VoidEvent GotIt;

    public void GotIt_EventCaller() {
        GotIt.Raise();
    }
}
