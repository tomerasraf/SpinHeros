using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject backgroundUI;

    private float endValueMenuOffset = 250;

    public void MenuButton_Listener() {
        menuUI.SetActive(true);

        menuUI.transform.DOMoveX(endValueMenuOffset, 1f);        


        backgroundUI.GetComponent<Image>().DOFade(0, 0).OnComplete(() =>
        {
            backgroundUI.SetActive(true);
            backgroundUI.GetComponent<Image>().DOFade(0.6f, 1);
        });
    }
}


