using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData _playerData;

    [Header("Events")]
    [SerializeField] VoidEvent updateUI;
    [SerializeField] VoidEvent damageBlink;
    [SerializeField] VoidEvent asteroidExplosion;
    [SerializeField] VoidEvent playerDie;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            damageBlink.Raise();
            _playerData.hearts--;
            updateUI.Raise();

            if (_playerData.hearts == 0)
            {
                _playerData.playerIsDead = true;
                PlayerDeath();
                return;
            }

            transform.GetComponent<Animator>().SetBool("PlayerGotHit", true);
            StartCoroutine(immuneTimer());
        }

        if (other.CompareTag("Asteroid"))
        {
            asteroidExplosion.Raise();
        }
    }

    IEnumerator immuneTimer()
    {
        while (_playerData.playerIsImmuneTime > 0)
        {
            transform.GetComponent<BoxCollider>().enabled = false;
            _playerData.playerIsImmuneTime -= Time.deltaTime;
            yield return null;
        }
        transform.GetComponent<BoxCollider>().enabled = true;
        yield return null;
    }

    void PlayerDeath()
    {
        Vector3 playerDeathRotation = new Vector3(90, transform.position.y, transform.position.z);
        transform.DORotate(playerDeathRotation, 0.7f);
        transform.GetComponent<Rigidbody>().useGravity = true;
        _playerData.playerIsDead = true;
        playerDie.Raise();
    }
}
