using UnityEngine;
using UnityEngine.UI;
using System.Collections;

class SpiningWheelTutorial : MonoBehaviour {

    [Header("Popouts")]
    [SerializeField] GameObject spinPopoutMassage;
    [SerializeField] GameObject coinPopoutMassage;
    [SerializeField] GameObject heartPopoutMassage;
    [SerializeField] GameObject miniGamePopoutMassage;
    [SerializeField] GameObject spinButtonPointer;
    [SerializeField] GameObject miniGamePointer;
    [SerializeField] GameObject testYourLuck;

    [Header("UI")]
    [SerializeField] GameObject coinBarUI;
    [SerializeField] GameObject heartsUI;

    [Header("Buttons")]
    [SerializeField] Button buildButton;
    [SerializeField] Button miniGameButton;
 
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

        buildButton.enabled = false;
        miniGameButton.enabled = false;
        TutorialAnimationUtils.MassagePopoutAnimation(massageStartSize, spinPopoutMassage, 1);
        TutorialAnimationUtils.PointerPopoutAnimation(pointerStartPosition, pointerStartSize, 50, spinButtonPointer, 1);
    }
    
    public void SpinButton_Listener() {
        TutorialAnimationUtils.RemoveMassageAnimation(spinPopoutMassage, 0.5f);

        TutorialAnimationUtils.RemoveMassageAnimation(coinPopoutMassage, 0.5f);
        TutorialAnimationUtils.RemoveMassageAnimation(heartPopoutMassage, 0.5f);
    }

    
    public void CoinIsEarned_Listener() {
        StartCoroutine(CoinDelay());
    }

    IEnumerator CoinDelay()
    {
        yield return new WaitForSeconds(3);
        TutorialAnimationUtils.ButtonPopoutAnimation(coinBarUI.transform.localScale, coinPopoutMassage, 1);
        TutorialAnimationUtils.ButtonPopoutAnimation(coinBarUI.transform.localScale, coinBarUI, 1);
        yield return null;
    }

    public void HeartIsEarned_Listener() {

        StartCoroutine(HeartDelay()); 
    }

    IEnumerator HeartDelay()
    {
        yield return new WaitForSeconds(4.5f);
        TutorialAnimationUtils.ButtonPopoutAnimation(coinBarUI.transform.localScale, heartPopoutMassage, 1);
        TutorialAnimationUtils.ButtonPopoutAnimation(heartsUI.transform.localScale, heartsUI, 1);
        yield return null;
    }

    public void MiniGameIsEarned_Listener() {

        miniGameButton.enabled = true;
        TutorialAnimationUtils.RemovePointerAnimation(spinButtonPointer, 0.5f);
        StartCoroutine(MiniGameDelay());
       
    }

    IEnumerator MiniGameDelay()
    {
        yield return new WaitForSeconds(6);
        TutorialAnimationUtils.ButtonPopoutAnimation(coinBarUI.transform.localScale, miniGamePopoutMassage, 1);
        TutorialAnimationUtils.MassagePopoutAnimation(new Vector3(1, 1, 1), miniGamePopoutMassage, 1);
        yield return null;
    }

    public void MiniGameButtonPressed_Listener() {
        buildButton.enabled = true;
        TutorialAnimationUtils.RemoveMassageAnimation(testYourLuck, 0.5f);
        TutorialAnimationUtils.RemovePointerAnimation(miniGamePointer, 0.5f);
    }
}
