using UnityEngine;

class CutsceneTutorial : MonoBehaviour {

    [SerializeField] GameObject pointer;

    public void StartPointer_Listener() {
        TutorialAnimationUtils.PointerPopoutAnimation(pointer.transform.position, pointer.transform.localScale, 30, pointer, 1);
    }

    public void RemovePointer_Listener()
    {
        TutorialAnimationUtils.RemovePointerAnimation(pointer, 1);
    }
}