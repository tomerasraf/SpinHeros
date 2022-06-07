using UnityEngine;

namespace Assets.Scripts.Simulation.Wheel_Machine
{
    public class MiniGameEffect : MonoBehaviour
    {
        private int ID = 1;
        [SerializeField] GameObject MiniGameEffectObject;
        [SerializeField] Transform startPosition;
        [SerializeField] RectTransform[] miniGameUI_Transform;
        [SerializeField] VoidEvent MiniGameUI_Updater;

        public void MiniGameEffect_Listener()
        {
            EffectAnimationUtils.WheelEffectAnimation(ID, MiniGameEffectObject, startPosition, miniGameUI_Transform, MiniGameUI_Updater);
        }
    }
}