using UnityEngine;
using System.Collections;

class CutsceneTutorial : MonoBehaviour {

    [SerializeField] GameObject pointer;

    public void StartPointer_Listener() {
        StartCoroutine(DelayAnimation());
    }

    IEnumerator DelayAnimation() {

        yield return new WaitForSeconds(3);
        TutorialAnimationUtils.PointerPopoutAnimation(pointer.transform.position, pointer.transform.localScale, 70, pointer, 0.3f);
        yield return null;
    }

    public void RemovePointer_Listener()
    {
        TutorialAnimationUtils.RemovePointerAnimation(pointer, 1);
    }
}