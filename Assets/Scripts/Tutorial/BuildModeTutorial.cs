using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts.Tutorial
{
    public class BuildModeTutorial : MonoBehaviour
    {

        [Header("Data")]
        [SerializeField] GameSettingsData _gameSettingsData;

        [Header("Pointers")]
        [SerializeField] GameObject popupMassage;
        [SerializeField] GameObject sliderPointer;
        [SerializeField] GameObject floatingPointer;
        [SerializeField] GameObject clickOnScreenPointer;

        [Header("vars")]
        [SerializeField] float animationSpeed;
        [SerializeField] float sliderPointerOffset;
        [SerializeField] float floatingPointerOffset;
        [SerializeField] float pointerSwitchCounter;
        [SerializeField] float slideTime;

        [Header("Buttons")]
        [SerializeField] Button clickOnScreenButton;

        [Header("UI")]
        [SerializeField] GameObject buildingSliderUI;

        [Header("Ruined Building")]
        [SerializeField] GameObject ruinedBuilding;

        [Header("Events")]
        [SerializeField] VoidEvent swichToWorldMode;
        
        private Vector3 buildingSliderStartPosition;
        private Vector3 popupMassageStartSize;
        private Vector3 sliderPointerStartSize;
        private Vector3 sliderPointerStartPosition;
        private Vector3 floatingPointerStartSize;
        private Vector3 floatingPointerStartPosition;

        private void Start()
        {
            buildingSliderStartPosition = buildingSliderUI.transform.position;
            popupMassageStartSize = popupMassage.transform.localScale;

            sliderPointerStartSize = sliderPointer.transform.localScale;
            sliderPointerStartPosition = sliderPointer.transform.position;

            floatingPointerStartSize = floatingPointer.transform.localScale;
            floatingPointerStartPosition = floatingPointer.transform.position;
        }

        public void DisplayBuildModePointer_Listener()
        {
            clickOnScreenButton.enabled = false;
            _gameSettingsData.buildControlsOff = true;
            TutorialAnimationUtils.RemoveMassageAnimation(popupMassage, 0.5f);
            TutorialAnimationUtils.PointerPopoutSideAnimation(sliderPointerStartPosition, sliderPointerStartSize, -sliderPointerOffset, sliderPointer, animationSpeed);
            TutorialAnimationUtils.SlideLeft(buildingSliderUI, buildingSliderStartPosition, slideTime);

            StartCoroutine(PointerSliderSwitch());
        }

        IEnumerator PointerSliderSwitch()
        {

            yield return new WaitForSeconds(pointerSwitchCounter);
            TutorialAnimationUtils.PointerPopoutAnimation(floatingPointerStartPosition, floatingPointerStartSize, floatingPointerOffset, floatingPointer, animationSpeed);

            yield return null;
        }

        public void HeroLiftOff() {

            StartCoroutine(DelayAnimation());
        }

        IEnumerator DelayAnimation() {

            yield return new WaitForSeconds(2);
            TutorialAnimationUtils.MassagePopoutAnimation(popupMassageStartSize, popupMassage, 1f);
            yield return null;
        }

        public void RemoveBuildModePointer_Listener()
        {
            swichToWorldMode.Raise();
            ruinedBuilding.SetActive(false);
            clickOnScreenButton.enabled = true;
            TutorialAnimationUtils.RemovePointerAnimation(floatingPointer, 0.5f);
            _gameSettingsData.buildControlsOff = false;
        }

        public void ClickOnScreen_Listener()
        {
            
            
        }


    }
}