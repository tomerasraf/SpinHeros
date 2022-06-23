using UnityEngine;


class MenuInput : MonoBehaviour
{
    [SerializeField] VoidEvent openMenuUI;

    public void OnClickMenuButton_Listener()
    {
        openMenuUI.Raise();
    }

}