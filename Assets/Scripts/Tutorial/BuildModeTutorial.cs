using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Tutorial
{
    public class BuildModeTutorial : MonoBehaviour
    {
        [Header("Pointers")]
        [SerializeField] GameObject popupMassage;
        [SerializeField] GameObject sliderPointer;
        [SerializeField] GameObject floatingPointer;

        [Header("vars")]
        [SerializeField] float animationSpeed;
        [SerializeField] float sliderPointerOffset;
        [SerializeField] float floatingPointerOffset;
        [SerializeField] float pointerSwitchCounter;

        private Vector3 popupMassageStartSize;

        private Vector3 sliderPointerStartSize;
        private Vector3 sliderPointerStartPosition;

        private Vector3 floatingPointerStartSize;
        private Vector3 floatingPointerStartPosition;

        private void Start()
        {
            popupMassageStartSize = popupMassage.transform.localScale;

            sliderPointerStartSize = sliderPointer.transform.localScale;
            sliderPointerStartPosition = sliderPointer.transform.position;

            floatingPointerStartSize = floatingPointer.transform.localScale;
            floatingPointerStartPosition = floatingPointer.transform.position;
        }

        public void DisplayBuildModePointer_Listener()
        {
            TutorialAnimationUtils.MassagePopoutAnimation(popupMassageStartSize, popupMassage, 1f);
            TutorialAnimationUtils.PointerPopoutSideAnimation(sliderPointerStartPosition, sliderPointerStartSize, -sliderPointerOffset, sliderPointer, animationSpeed);
            StartCoroutine(PointerSliderSwitch());
        }

        IEnumerator PointerSliderSwitch() {

            yield return new WaitForSeconds(pointerSwitchCounter);
            TutorialAnimationUtils.PointerPopoutAnimation(floatingPointerStartPosition, floatingPointerStartSize, floatingPointerOffset, floatingPointer, animationSpeed);

            yield return null;
        }

        public void RemoveBuildModePointer_Listener() {
            TutorialAnimationUtils.RemovePointerAnimation(floatingPointer, 0.5f);
        }


    }
}