using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Simulation.Wheel_Machine
{
    public class HeartEffect : MonoBehaviour
    {
        [SerializeField] PlayerData _playerData;
        [SerializeField] GameObject heartModel_Prefab;
        [SerializeField] Transform startPosition;
        [SerializeField] RectTransform[] heartUI_Transform;
        [SerializeField] VoidEvent heartUI_Updater;



        private GameObject heartEffectClone;
        public void HeartEffectAnimation_Listener()
        {

            if (heartEffectClone == null)
            {
                heartEffectClone = Instantiate(heartModel_Prefab, startPosition.position + Vector3.up * 15, Quaternion.identity);
                heartEffectClone.transform.DOMoveY(startPosition.position.y + 0.2f, 1f).OnComplete(() =>
                {

                    heartEffectClone.transform.DOMoveY(startPosition.position.y + 0.7f, 1f * 0.5f).SetEase(Ease.InOutSine).SetLoops(1, LoopType.Yoyo).OnComplete(() =>
                    {
                        heartEffectClone.transform.DOScale(0.05f, 0.7f);
                        Vector2 screenPoint = heartUI_Transform[_playerData.hearts - 1].position;
                        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);


                        RectTransformUtility.ScreenPointToWorldPointInRectangle(heartUI_Transform[_playerData.hearts - 1], screenPoint, Camera.main, out worldPos);
                        heartEffectClone.transform.DOMove(worldPos, 0.7f).OnComplete(() =>
                        {
                            Destroy(heartEffectClone);
                            heartUI_Updater.Raise();
                        });
                    });

                });
            }
            heartEffectClone.transform.DOLocalRotate(new Vector3(0, 360, 0), 5f * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

        }

    }
}
