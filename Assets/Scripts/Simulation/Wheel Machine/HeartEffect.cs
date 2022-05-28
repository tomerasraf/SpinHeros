using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Assets.Scripts.Simulation.Wheel_Machine
{
    public class HeartEffect : MonoBehaviour
    {
        [SerializeField] GameObject heartModel_Prefab;
        [SerializeField] Transform startPosition;

        public void HeartEffectAnimation_Listener() {
            GameObject heartEffectClone = Instantiate(heartModel_Prefab, startPosition.position, new Quaternion(30, 0, 0,0));
            heartEffectClone.transform.DOMoveY(startPosition.position.y + 15, 0);
            heartEffectClone.transform.DOMoveY(startPosition.position.y + 0.2f, 1f);
            heartEffectClone.transform.DORotate(new Vector3(0, 360, 0), 2f * 0.5f,RotateMode.FastBeyond360).SetLoops(-1,LoopType.Restart);
        }
    }
}