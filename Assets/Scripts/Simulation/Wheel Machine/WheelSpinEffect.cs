using DG.Tweening;
using UnityEngine;
public class WheelSpinEffect : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameObject wheelSpinEffect_Object;

    private void Start()
    {
        wheelSpinEffect_Object.transform.DOScale(0, 0);
        
    }

    public void wheelSpinEffect_Listiner()
    {
        if (_playerData.spins == 0)
        {
            return;
        }

        wheelSpinEffect_Object.transform.DORewind();

        wheelSpinEffect_Object.transform.DOScale(3.69f, 0.2f).OnComplete(() =>
        {
            wheelSpinEffect_Object.transform.DOScale(0, 3f);
        });
    }
}
