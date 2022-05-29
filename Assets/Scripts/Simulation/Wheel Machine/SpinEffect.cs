using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Assets.Scripts.Simulation.Wheel_Machine
{
    public class SpinEffect : MonoBehaviour
    {
        private int ID = 1;
        [SerializeField] GameObject spinEffectObject;
        [SerializeField] Transform startPosition;
        [SerializeField] RectTransform[] spinBar_Transform;
        [SerializeField] VoidEvent extraSpinBarUI_Updater;

        public void GainingSpinAnimation_Listener() {
            EffectAnimationUtil.WheelEffectAnimation(ID, spinEffectObject, startPosition, spinBar_Transform, extraSpinBarUI_Updater);
        }

    }
}