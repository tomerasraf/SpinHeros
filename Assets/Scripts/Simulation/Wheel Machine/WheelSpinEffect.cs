using DG.Tweening;
using UnityEngine;
public class WheelSpinEffect : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameObject wheelSpinEffect_Object;

    public void wheelSpinEffect_Listiner()
    {
        if (_playerData.spins == 0)
        {
            return;
        }
        wheelSpinEffect_Object.transform.DOScale(0, 0);

        wheelSpinEffect_Object.SetActive(true);

        wheelSpinEffect_Object.transform.DOScale(3.69f, 0.2f).OnComplete(() =>
        {

            wheelSpinEffect_Object.transform.DOScale(0, 3f).OnComplete(() =>
            {
                wheelSpinEffect_Object.SetActive(false);
            });
        });

    }
}
