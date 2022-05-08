using UnityEngine;

public class BuildMode : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] WorldData _worldData;

    [Header("Building UI Min & Max move limit")]
    [SerializeField] float minLimitedValue;
    [SerializeField] float maxLimitedValue;

    [Header("Slider Object")]
    [SerializeField] GameObject buildingsUI_Slider;

    [Header("Slide Sensitivity")]
    [SerializeField] float slideSensitivity;
    [SerializeField] float smoothSpeed;

    private Vector3 endTouchPosition;

    public void BuildingModeIsOn()
    {
        _worldData.buldingModeIsOn = true;
    }

    private void Update()
    {
        if (!_worldData.buldingModeIsOn) { return; }

        endTouchPosition = TouchInput.DetectTouchInput(minLimitedValue, maxLimitedValue);

        Vector3 smoothedPosition = Vector3.Lerp(buildingsUI_Slider.transform.position, endTouchPosition, smoothSpeed);

        Vector3 newUIPosition = new Vector3(smoothedPosition.x * slideSensitivity * Time.fixedDeltaTime, buildingsUI_Slider.transform.position.y, buildingsUI_Slider.transform.position.z);

        buildingsUI_Slider.transform.position = newUIPosition;
    }

}
