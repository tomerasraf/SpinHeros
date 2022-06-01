using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour
{
    [SerializeField] GameObject[] targetsImg;

    private void Start()
    {
        for (int i = 0; i < targetsImg.Length; i++)
        {
            targetsImg[i].SetActive(false);
        }
    }

    public void targetUI_Enable()
    {
        for (int i = 0; i < targetsImg.Length; i++)
        {
            targetsImg[i].SetActive(true);
        }

    }
    public void targetUI_Disable()
    {
        for (int i = 0; i < targetsImg.Length; i++)
        {
            targetsImg[i].SetActive(false);
        }
    }
}