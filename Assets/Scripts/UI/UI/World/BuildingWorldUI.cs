using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuildingWorldUI : MonoBehaviour
{
    [SerializeField] WorldData _worldData;
    [SerializeField] GameObject builderUI;
    [SerializeField] GameObject spinButtonUI;
    [SerializeField] GameObject miniGameButtonUI;
    [SerializeField] GameObject buildModeButtonUI;
    [SerializeField] GameObject[] successUI;
    [SerializeField] GameObject[] buildButtonsUI;

    private float offsetUI = 760;
    private Vector3 spinButtonStartPos;
    private Vector3 builderUIStartPos;
    private Vector3 miniGameButtonStartPos;
    private Vector3 buildModeButtonStartPos;

    private void Start()
    {
        spinButtonStartPos = spinButtonUI.transform.position;
        builderUIStartPos = builderUI.transform.position;
        miniGameButtonStartPos = miniGameButtonUI.transform.position;
        buildModeButtonStartPos = buildModeButtonUI.transform.position;
    }
    public void DisplayBuilderUI()
    {
        builderUI.SetActive(true);
        // spinButtonUI.SetActive(false);
        // miniGameButtonUI.SetActive(false);
        // buildModeButtonUI.SetActive(false);
    }

    public void DisplayWorldUI()
    {
        //builderUI.SetActive(false);
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

    public void BuildModeUIAnimation_Listener()
    {
        spinButtonUI.transform.DOMoveY(spinButtonStartPos.y - offsetUI, 1);
        buildModeButtonUI.transform.DOMoveX(buildModeButtonStartPos.x + offsetUI, 1);
        miniGameButtonUI.transform.DOMoveX(miniGameButtonStartPos.x - offsetUI, 1);

        builderUI.transform.DOMoveY(builderUIStartPos.y - offsetUI, 0);
        builderUI.transform.DOMoveY(builderUIStartPos.y, 1);
    }

    public void ExitBuildModeUIAnimation_Listener()
    {
        builderUI.transform.DOMoveY(builderUIStartPos.y - offsetUI, 1);

        spinButtonUI.transform.DOMoveY(spinButtonStartPos.y, 1);
        buildModeButtonUI.transform.DOMoveX(buildModeButtonStartPos.x, 1);
        miniGameButtonUI.transform.DOMoveX(miniGameButtonStartPos.x, 1);
    }
}