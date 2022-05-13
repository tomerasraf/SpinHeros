using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    [SerializeField] GameObject wheel;
    [SerializeField] GameObject footer;
    [SerializeField] GameObject spinButton;


    public void DisplayUI_On()
    {
        wheel.SetActive(true);
        footer.SetActive(true);
        spinButton.SetActive(true);
    }
}