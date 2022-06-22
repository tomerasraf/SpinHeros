using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingWorldUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] WorldData _worldData;

    [Header("UI")]
    [SerializeField] GameObject builderUI;
    [SerializeField] GameObject spinButtonUI;
    [SerializeField] GameObject miniGameButtonUI;
    [SerializeField] GameObject buildModeButtonUI;
    [SerializeField] GameObject[] successUI;
    [SerializeField] GameObject[] buildButtonsUI;
    [SerializeField] GameObject CantAfford;

    private GameObject cantAffordClone;

    private float offsetUI = 1500;
    private Vector3 spinButtonStartPos;
    private Vector3 builderUIStartPos;
    private Vector3 miniGameButtonStartPos;
    private Vector3 buildModeButtonStartPos;

    private void Start()
    {
        LoadBuildButtonData();
        InitializeStartPositions();
    }

    private void InitializeStartPositions()
    {
        spinButtonStartPos = spinButtonUI.transform.position;
        builderUIStartPos = builderUI.transform.position;
        miniGameButtonStartPos = miniGameButtonUI.transform.position;
        buildModeButtonStartPos = buildModeButtonUI.transform.position;
    }

    private void LoadBuildButtonData()
    {
        for (int i = 0; i < _worldData.isBuilded.Length; i++)
        {
            if (_worldData.isBuilded[i])
            {
                buildButtonsUI[i].SetActive(false);
                successUI[i].SetActive(true);
            }
        }
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
        spinButtonUI.GetComponent<Button>().enabled = false;
        miniGameButtonUI.GetComponent<Button>().enabled = false;
        buildModeButtonUI.GetComponent<Button>().enabled = false;


        spinButtonUI.transform.DOMoveY(spinButtonStartPos.y - offsetUI, 1).SetEase(Ease.InBack);
        buildModeButtonUI.transform.DOMoveX(buildModeButtonStartPos.x + offsetUI, 1).SetEase(Ease.InBack);
        miniGameButtonUI.transform.DOMoveX(miniGameButtonStartPos.x - offsetUI, 1).SetEase(Ease.InBack);

        builderUI.transform.DOMoveY(builderUIStartPos.y - offsetUI, 0);
        builderUI.transform.DOMoveY(builderUIStartPos.y, 1).SetEase(Ease.InBack).OnComplete(() =>
        {
            spinButtonUI.GetComponent<Button>().enabled = enabled;
            miniGameButtonUI.GetComponent<Button>().enabled = enabled;
            buildModeButtonUI.GetComponent<Button>().enabled = enabled;
        });
    }

    public void ExitBuildModeUIAnimation_Listener()
    {
        builderUI.transform.DOMoveY(builderUIStartPos.y - offsetUI, 1).SetEase(Ease.OutBack);

        spinButtonUI.transform.DOMoveY(spinButtonStartPos.y, 1).SetEase(Ease.OutBack);
        buildModeButtonUI.transform.DOMoveX(buildModeButtonStartPos.x, 1).SetEase(Ease.OutBack);
        miniGameButtonUI.transform.DOMoveX(miniGameButtonStartPos.x, 1).SetEase(Ease.OutBack);
    }

    public void CantAfford_Listener(int buttonID)
    {

        Vector3 massageStartPosition = buildButtonsUI[buttonID].transform.position;

        if (cantAffordClone == null)
        {
            cantAffordClone = Instantiate(CantAfford, massageStartPosition, Quaternion.identity, buildButtonsUI[buttonID].transform);

            TextMeshProUGUI cantAffordText = cantAffordClone.GetComponent<TextMeshProUGUI>();

            cantAffordText.DOFade(0, 0).OnComplete(() =>
            {
                cantAffordClone.transform.DOScale(1.3f, 0);
                cantAffordClone.transform.DOMoveY(massageStartPosition.y + 70, 1.5f);
                cantAffordText.DOFade(1, 1.5f).OnComplete(() =>
                {
                    cantAffordText.DOFade(0, 1.5f).OnComplete(() =>
                    {
                        Destroy(cantAffordClone);
                    });
                });
            });
        }
    }
}