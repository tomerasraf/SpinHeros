using UnityEngine;
using DG.Tweening;

public class SpinWheelLogic : MonoBehaviour
{

    [Header("Data")]
    [SerializeField] SpiningWheelData _spiningWheelData;

    [Header("Events")]
    [SerializeField] VoidEvent spinIsEnded;

    [Header("Transform")]
    [SerializeField] Transform wheel;

    [Header("Var")]
    [SerializeField] float stopSpinTime = 1;
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

        wheel.DORotate(endValue, stopSpinTime, RotateMode.FastBeyond360).SetEase(Ease.OutBack).OnComplete(() =>
        {
            spinIsEnded.Raise();
        });
    }

    private void RamdomSpin()
    {
        int rand = Random.Range(0, 100);
        _spiningWheelData.result = _spiningWheelData.wheelSlots[rand];
    }
}
