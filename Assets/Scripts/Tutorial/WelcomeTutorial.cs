using UnityEngine;
using System.Collections;

public class WelcomeTutorial : MonoBehaviour
{
    [SerializeField] GameObject massage;
    [SerializeField] GameObject buildButton;
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

    public void HeroIsLowering_Listener() {
        StartCoroutine(animationDelay());
    }

    public void HeroIsBlowingAir() {
        TutorialAnimationUtils.RemoveMassageAnimation(massage, animationSpeed);
    }

    IEnumerator animationDelay() {

        yield return new WaitForSeconds(4);
        TutorialAnimationUtils.MassagePopoutAnimation(massageStartSize, massage, animationSpeed);
        yield return null;
    }
    

    public void DisplayWelcome_Listener()
    {
        
        TutorialAnimationUtils.PointerPopoutAnimation(pointerStartPosition, pointerStartSize, -pointerOffset, pointer, animationSpeed);
        TutorialAnimationUtils.ButtonPopoutAnimation(buildButton.transform.localScale, buildButton, 1);
    }

    public void DisplayOffWelcome_Listener() {
        TutorialAnimationUtils.RemovePointerAnimation(pointer, animationSpeed);
        
    }

}
