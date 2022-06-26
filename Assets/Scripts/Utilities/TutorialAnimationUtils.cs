using DG.Tweening;
using UnityEngine;

public static class TutorialAnimationUtils
{
    public static void ButtonPopoutAnimation(Vector3 buttonSize, GameObject button, float animationTime) {
        button.transform.DOScale(0, 0).OnComplete(() =>
        {
            button.SetActive(true);
        });

        button.transform.DOScale(buttonSize, animationTime);
    }

    public static void MassagePopoutAnimation(Vector3 massageStartSize, GameObject massageUI, float speedOfPopout)
    {
        massageUI.transform.DOScale(0, 0).OnComplete(() =>
        {
            massageUI.SetActive(true);
        });

        massageUI.transform.DOScale(massageStartSize, speedOfPopout).SetEase(Ease.OutBounce);
    }

    public static void RemoveMassageAnimation(GameObject massageUI, float speedOfRemove)
    {
        massageUI.transform.DOScale(0, speedOfRemove).OnComplete(() =>
        {
            massageUI.SetActive(false);
        });
    }

    public static void PointerPopoutAnimation(Vector3 startPosition, Vector3 pointerStartSize, float pointerOffset, GameObject pointer, float animationSpeed)
    {
        pointer.transform.DOScale(0, 0).OnComplete(() =>
        {
            pointer.SetActive(true);
            pointer.transform.DOScale(pointerStartSize, animationSpeed).SetEase(Ease.OutBounce);
        });

        pointer.transform.DOMoveY(startPosition.y - pointerOffset, animationSpeed).SetLoops(-1, LoopType.Yoyo);
    }

    public static void PointerPopoutSideAnimation(Vector3 startPosition, Vector3 pointerStartSize, float pointerOffset, GameObject pointer, float animationSpeed) {
        pointer.transform.DOScale(0, 0).OnComplete(() =>
        {
            pointer.SetActive(true);
            pointer.transform.DOScale(pointerStartSize, animationSpeed).SetEase(Ease.OutBounce);
        });

        pointer.transform.DOMoveX(startPosition.x + pointerOffset, animationSpeed).SetLoops(2, LoopType.Yoyo).OnComplete(() => {
            RemovePointerAnimation(pointer, 0.5f);
        });
    }

    public static void RemovePointerAnimation(GameObject poiner, float speedOfRemove)
    {
        poiner.transform.DOScale(0, speedOfRemove).OnComplete(() =>
        {
            poiner.SetActive(false);
        });
    }


    public static void SlideLeft(GameObject slider , Vector3 startposition , float animationTime) {

        slider.transform.DOMoveX(-717, 0).OnComplete(() => {
            slider.transform.DOMoveX(startposition.x, animationTime);
        });
        

    }
}
