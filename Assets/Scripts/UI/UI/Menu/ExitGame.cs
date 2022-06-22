using DG.Tweening;
using UnityEngine;

class ExitGame : MonoBehaviour
{

    [SerializeField] GameObject exitMassage;

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void CloseTheQuitMassage() {
        exitMassage.transform.DOScale(0, 1);
        exitMassage.SetActive(false);
    }

}
