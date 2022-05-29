using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Simulation.Wheel_Machine
{
    public class HeartEffect : MonoBehaviour
    {
        [SerializeField] PlayerData _playerData;
        [SerializeField] GameObject effectObject;
        [SerializeField] Transform startPosition;
        [SerializeField] RectTransform[] heartUI_Transform;
        [SerializeField] VoidEvent heartUI_Updater;



        private GameObject heartEffectClone;
        public void HeartEffectAnimation_Listener()
        {
            EffectAnimationUtil.WheelEffectAnimation(_playerData.hearts, effectObject, startPosition, heartUI_Transform, heartUI_Updater);
        }

    }
}
