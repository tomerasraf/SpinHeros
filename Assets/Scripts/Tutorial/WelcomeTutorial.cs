using UnityEngine;

public class WelcomeTutorial : MonoBehaviour
{
    [SerializeField] GameObject massage;
    [SerializeField] GameObject pointer;
    [SerializeField] float animationSpeed;
    [SerializeField] float pointerOffset;

    private Vector3 massageStartSize;
    private Vector3 pointerStartSize;
    private Vector3 pointerStartPosition;

    private void Start()
    {
        massageStartSize = massage.transform.localScale;
        pointerStartSize = pointer.transform.localScale;
        pointerStartPosition = pointer.transform.position;

       // TutorialAnimationUtils.MassagePopoutAnimation(massageStartSize, massage, animationSpeed);
       // TutorialAnimationUtils.PointerPopoutAnimation(pointerStartPosition, pointerStartSize, -pointerOffset, pointer, animationSpeed);
    }

    public void DisplayWelcome_Listener()
    {
        TutorialAnimationUtils.MassagePopoutAnimation(massageStartSize, massage, animationSpeed);
        TutorialAnimationUtils.PointerPopoutAnimation(pointerStartPosition, pointerStartSize, -pointerOffset, pointer, animationSpeed);
    }

    public void DisplayOffWelcome_Listener() {
        TutorialAnimationUtils.RemovePointerAnimation(pointer, animationSpeed);
        TutorialAnimationUtils.RemoveMassageAnimation(massage, animationSpeed);
    }

}
