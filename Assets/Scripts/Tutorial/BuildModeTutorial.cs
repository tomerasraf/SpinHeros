using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Tutorial
{
    public class BuildModeTutorial : MonoBehaviour
    {
        [SerializeField] GameObject pointer;
        [SerializeField] float animationSpeed;
        [SerializeField] float pointerOffset;

        private Vector3 pointerStartSize;
        private Vector3 pointerStartPosition;

        private void Start()
        { 
            pointerStartSize = pointer.transform.localScale;
            pointerStartPosition = pointer.transform.position;
        }

        public void DisplayBuildModePointer_Listener()
        {
            TutorialAnimationUtils.PointerPopoutSideAnimation(pointerStartPosition, pointerStartSize, -pointerOffset, pointer, animationSpeed);
        }

        public void DisplayOffBuildModePointer_Listener()
        {
            TutorialAnimationUtils.RemovePointerAnimation(pointer, animationSpeed);
        }
    }
}