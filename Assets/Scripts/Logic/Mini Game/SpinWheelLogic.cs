using UnityEngine;
using DG.Tweening;

public class SpinWheelLogic : MonoBehaviour
{

    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Transform")]
    [SerializeField] Transform wheel;
    [Header("Var")]
    [SerializeField] float symbolOffset = 45;
    [SerializeField] float wheelSpeed = 20;
    [SerializeField] float timeOfWheelSpin;

    public void WheelSpinLogic()
    {
        RamdomSpin();
        SpinWheel();
    }

    private void SpinWheel()
    {
        Vector3 endValue = new Vector3(
                        wheel.rotation.x,
                        wheel.rotation.y,
                        symbolOffset * wheelSpeed
                      );

        wheel.DORotate(endValue, timeOfWheelSpin, RotateMode.FastBeyond360).SetEase(Ease.Flash).OnComplete(() =>
        {
            StopWheel();
        });
    }

    private void StopWheel()
    {
        Vector3 endValue = new Vector3(
                        wheel.rotation.x,
                        wheel.rotation.y,
                        _spiningWheelData.result * symbolOffset
                      );
        Debug.Log(_spiningWheelData.result);

        wheel.DORotate(endValue, 2f, RotateMode.FastBeyond360).SetEase(Ease.OutBack); ;
    }

    private void RamdomSpin()
    {
        int rand = Random.Range(0, 100);
        _spiningWheelData.result = _spiningWheelData.wheelSlots[rand];
    }
}
