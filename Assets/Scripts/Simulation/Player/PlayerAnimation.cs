using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] Animator _playerAnimator;

    public void PlayJump_Listener()
    {
        if (_playerData.miniGameTicket > 0)
        {
            StartCoroutine(PlayJumpAnimation_Corotine());
        }
        else
        {
            return;
        }
    }

    IEnumerator PlayJumpAnimation_Corotine()
    {
        _playerAnimator.SetBool("EnterMiniGame", true);
        yield return new WaitForSeconds(1.2f);
        transform.DOMoveY(-2f, 0.2f);

        yield return null;
    }
}