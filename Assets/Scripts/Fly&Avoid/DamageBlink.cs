using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlink : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData _playerData;

    [Header("Mesh Renderers")]
    [SerializeField] MeshRenderer cape;
    [SerializeField] MeshRenderer playerMask;
    [SerializeField] SkinnedMeshRenderer head;
    [SerializeField] SkinnedMeshRenderer hands;
    [SerializeField] SkinnedMeshRenderer legs;

    [Header("Damage Blink Vars")]
    [SerializeField] float blinkSpeed;
    [SerializeField] float playerImmuneCoolDown;

    public void DamageBlink_Listener() {

        StartCoroutine(Blink());
    }

    private IEnumerator Blink() {

        while (_playerData.playerIsImmuneTime > 0) {
            
            yield return new WaitForSeconds(blinkSpeed);

            DisableAllMashRenderers();

            yield return new WaitForSeconds(blinkSpeed);

            EnableAllMashRenderers();

            yield return null;
        }

        _playerData.playerIsImmuneTime = playerImmuneCoolDown;
        transform.GetComponent<Animator>().SetBool("PlayerGotHit", false);
        yield return null;
    }

    private void DisableAllMashRenderers() {

        cape.enabled = false;
        playerMask.enabled = false;
        head.enabled = false;
        hands.enabled = false;
        legs.enabled = false;

    }
    
    private void EnableAllMashRenderers() {

        cape.enabled = enabled;
        playerMask.enabled = enabled;
        head.enabled = enabled;
        hands.enabled = enabled;
        legs.enabled = enabled;
    }
}
