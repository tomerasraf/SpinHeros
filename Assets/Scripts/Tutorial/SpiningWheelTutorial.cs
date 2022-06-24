using UnityEngine;
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
        TutorialAnimationUtils.ButtonPopoutAnimation(coinBarUI.transform.localScale, coinBarUI, 1);

        TutorialAnimationUtils.MassagePopoutAnimation(new Vector3(1,1,1) , coinPopoutMassage, 1);
        StartCoroutine(RemovePopoutCoinTimer());
    } 
    public void HeartIsEarned_Listener() {
        TutorialAnimationUtils.ButtonPopoutAnimation(heartsUI.transform.localScale, heartsUI, 1);

        TutorialAnimationUtils.MassagePopoutAnimation(new Vector3(1, 1, 1), heartPopoutMassage, 1);
        StartCoroutine(RemovePopoutHeartTimer());
    }
    public void MiniGameIsEarned_Listener() {
        TutorialAnimationUtils.MassagePopoutAnimation(new Vector3(1, 1, 1), miniGamePopoutMassage, 1);
        StartCoroutine(RemovePopoutMiniGameTimer());
    }

    public void MiniGameButtonPressed_Listener() {
        TutorialAnimationUtils.RemoveMassageAnimation(testYourLuck, 0.5f);
        TutorialAnimationUtils.RemovePointerAnimation(miniGamePointer, 0.5f);
    }

    IEnumerator RemovePopoutCoinTimer() {

        yield return new WaitForSeconds(3f);

        TutorialAnimationUtils.RemoveMassageAnimation(coinPopoutMassage, 0.5f);

        yield return null;
    }
    IEnumerator RemovePopoutHeartTimer() {

        yield return new WaitForSeconds(3f);

        TutorialAnimationUtils.RemoveMassageAnimation(heartPopoutMassage, 0.5f);

        yield return null;
    }
    IEnumerator RemovePopoutMiniGameTimer() {

        yield return new WaitForSeconds(3f);

        TutorialAnimationUtils.RemoveMassageAnimation(miniGamePopoutMassage, 0.5f);

        yield return new WaitForSeconds(0.5f);

        TutorialAnimationUtils.MassagePopoutAnimation(new Vector3(1, 1, 1), testYourLuck, 1);
        TutorialAnimationUtils.PointerPopoutAnimation(miniGamePointer.transform.position, new Vector3(1, 1, 1), 40, miniGamePointer, 1);

        yield return null;
    }

}
