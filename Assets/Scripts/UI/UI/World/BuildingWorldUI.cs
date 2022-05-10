using UnityEngine;
using UnityEngine.UI;

public class BuildingWorldUI : MonoBehaviour
{
    [SerializeField] WorldData _worldData;
    [SerializeField] GameObject builderUI;
    [SerializeField] GameObject spinButtonUI;
    [SerializeField] GameObject miniGameButtonUI;
    [SerializeField] GameObject buildModeButtonUI;
    [SerializeField] GameObject[] successUI;
    [SerializeField] GameObject[] buildButtonsUI;
    public void DisplayBuilderUI()
    {
        builderUI.SetActive(true);
        spinButtonUI.SetActive(false);
        miniGameButtonUI.SetActive(false);
        buildModeButtonUI.SetActive(false);
    }

    public void DisplayWorldUI()
    {
        builderUI.SetActive(false);
        spinButtonUI.SetActive(true);
        miniGameButtonUI.SetActive(true);
        buildModeButtonUI.SetActive(true);
    }

    public void BuildIsDone(int id)
    {
        if (!_worldData.isBuilded[id]) { return; }

        buildButtonsUI[id].SetActive(false);
        successUI[id].SetActive(true);

    }
}