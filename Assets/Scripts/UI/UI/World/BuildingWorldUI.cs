using UnityEngine;

public class BuildingWorldUI : MonoBehaviour
{
    [SerializeField] GameObject builderUI;
    public void DisplayBuilderUI()
    {
        builderUI.SetActive(true);
    }
}