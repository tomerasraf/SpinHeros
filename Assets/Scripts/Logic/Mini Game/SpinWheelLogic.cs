using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Button")]
    [SerializeField] Button spinButton;

    private bool wheelIsSpining;

    public void WheelSpinLogic()
    {
        if (wheelIsSpining) { return; }
        wheelIsSpining = true;
        spinButton.enabled = false;
        RamdomSpin();
        SpinWheel();
    }

    private void SpinWheel()
    {
        Vector3 endValue = new Vector3(
                        wheel.rotation.x,
                        symbolOffset * wheelSpeed,
                        wheel.rotation.z
                      );

        wheel.DOLocalRotate(endValue, timeOfWheelSpin, RotateMode.FastBeyond360).SetEase(Ease.Flash).OnComplete(() =>
        {
            StopWheel();
        });
    }

    private void StopWheel()
    {
        Vector3 endValue = new Vector3(
                        wheel.rotation.x,
                        _spiningWheelData.results[0] * symbolOffset + 360,
                        wheel.rotation.z
                      );
        wheel.DOLocalRotate(endValue, stopSpinTime, RotateMode.FastBeyond360).SetEase(Ease.InSine).SetEase(Ease.OutBack).OnComplete(() =>
        {
            spinIsEnded.Raise();
            wheelIsSpining = false;
            spinButton.enabled = true;
        });
    }

    private void RamdomSpin()
    {
        for (int i = 0; i < _spiningWheelData.results.Length; i++)
        {
            int rand = 0;
            rand = Random.Range(0, 100);
            _spiningWheelData.results[i] = _spiningWheelData.wheelsSlots[rand];
        }
    }
}
