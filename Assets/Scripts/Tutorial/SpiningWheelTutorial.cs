using UnityEngine;

class SpiningWheelTutorial : MonoBehaviour {

    [SerializeField] GameObject spinPopoutMassage;
    [SerializeField] GameObject coinPopoutMassage;
    [SerializeField] GameObject HeartPopoutMassage;
    [SerializeField] GameObject MiniGamePopoutMassage;
    [SerializeField] GameObject spinButtonPointer;

    private Vector3 massageStartSize;
    private Vector3 pointerStartSize;
    private Vector3 pointerStartPosition;

    private void Start()
    {
        massageStartSize = spinPopoutMassage.transform.localScale;
        pointerStartSize = spinButtonPointer.transform.localScale;
        pointerStartPosition = spinButtonPointer.transform.position;
    }

    public void ExitBuildMode_Listener() {
        TutorialAnimationUtils.MassagePopoutAnimation(massageStartSize, spinPopoutMassage, 1);
        TutorialAnimationUtils.PointerPopoutAnimation(pointerStartPosition, pointerStartSize, 50, spinButtonPointer, 1);
    }

    public void SpinButton_Listener() {
        TutorialAnimationUtils.RemoveMassageAnimation(spinPopoutMassage, 0.5f);
        TutorialAnimationUtils.RemovePointerAnimation(spinButtonPointer, 0.5f);
    }

    public void CoinIsEarned_Listener() { 
        
    } 
    public void HeartIsEarned_Listener() { 
        
    }
    public void MiniGameIsEarned_Listener() { 
        
    }
}
