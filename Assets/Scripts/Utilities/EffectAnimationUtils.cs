using UnityEngine;
using DG.Tweening;

public static class EffectAnimationUtils
{
    public static void WheelEffectAnimation(int ID, GameObject effectModel, Transform startPosition, RectTransform[] UITransform, VoidEvent UIEventUpdater)
    {
        effectModel.transform.DOScale(1, 0);
        effectModel.transform.position = startPosition.position + Vector3.up * 15;
        effectModel.SetActive(true); 
        effectModel.transform.DOMoveY(startPosition.position.y + 0.2f, 1f).OnComplete(() =>
        {

            effectModel.transform.DOMoveY(startPosition.position.y + 0.7f, 1f * 0.5f).SetEase(Ease.InOutSine).SetLoops(3, LoopType.Yoyo).OnComplete(() =>
            {
                effectModel.transform.DOScale(0.05f, 0.7f);
                Vector2 screenPoint = UITransform[ID - 1 ].position;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);


                RectTransformUtility.ScreenPointToWorldPointInRectangle(UITransform[ID - 1], screenPoint, Camera.main, out worldPos);
                effectModel.transform.DOMove(worldPos, 0.7f).OnComplete(() =>
                {
                    effectModel.SetActive(false);
                    UIEventUpdater.Raise();
                });
            });

        });
        effectModel.transform.DOLocalRotate(new Vector3(0, 360, 0), 5f * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }


}
