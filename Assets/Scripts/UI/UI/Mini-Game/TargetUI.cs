using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour
{
    [SerializeField] Image[] targetsImg;

    private void Start()
    {
        for (int i = 0; i < targetsImg.Length; i++)
        {
            targetsImg[i].enabled = false;
        }
    }

    public void targetUI_Enable()
    {
        for (int i = 0; i < targetsImg.Length; i++)
        {
            targetsImg[i].enabled = true;
        }

    }
    public void targetUI_Disable()
    {
        for (int i = 0; i < targetsImg.Length; i++)
        {
            targetsImg[i].enabled = false;
        }
    }
}