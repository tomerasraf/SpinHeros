using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    public void DisplayUI_On()
    {
        canvas.gameObject.SetActive(enabled);
    }
}