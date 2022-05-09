using UnityEngine;

public class BuildingWorldUI : MonoBehaviour
{
    [SerializeField] GameObject builderUI;
    [SerializeField] GameObject spinButtonUI;
    [SerializeField] GameObject miniGameButtonUI;
    [SerializeField] GameObject buildButtonUI;
    public void DisplayBuilderUI()
    {
        builderUI.SetActive(true);
        spinButtonUI.SetActive(false);
        miniGameButtonUI.SetActive(false);
        buildButtonUI.SetActive(false);
    }

    public void DisplayWorldUI()
    {
        builderUI.SetActive(false);
        spinButtonUI.SetActive(true);
        miniGameButtonUI.SetActive(true);
        buildButtonUI.SetActive(true);
    }
}