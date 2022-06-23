using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

class MenuUI : MonoBehaviour
{
    [SerializeField] SystemData systemData;
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject backgroundUI;
    [SerializeField] float endValueMenuOffset = 250;

    private Vector3 menuStartPosition;

    private void Start()
    {
        menuStartPosition = menuUI.transform.position;
    }

    public void MenuButton_Listener() {
        systemData.inMenu = true;
        menuUI.SetActive(true);

        menuUI.transform.DOMoveX(endValueMenuOffset, 1f);        
        backgroundUI.GetComponent<Image>().DOFade(0, 0).OnComplete(() =>
        {
            backgroundUI.SetActive(true);
            backgroundUI.GetComponent<Image>().DOFade(0.6f, 1);
        });
    }

    public void BackButton_Listener() {
        menuUI.transform.DOMoveX(menuStartPosition.x, 1.2f).OnComplete(()=> {
            menuUI.SetActive(false);
            systemData.inMenu = false;
        });

        backgroundUI.GetComponent<Image>().DOFade(0, 1f).OnComplete(() => {
            backgroundUI.SetActive(false);
        });
    }
}


