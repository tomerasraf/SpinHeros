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
    [SerializeField] VoidEvent defeat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            damageBlink.Raise();
            _playerData.hearts--;
            updateUI.Raise();
            transform.GetComponent<Animator>().SetBool("PlayerGotHit", true);

            if (_playerData.hearts == 0)
            {
                _playerData.playerIsDead = true;
                PlayerDeath();
                return;
            }

         
            StartCoroutine(immuneTimer());
        }

        if (other.CompareTag("Asteroid"))
        {
            asteroidExplosion.Raise();
        }


        if (other.CompareTag("Coin")) {

            Destroy(other.gameObject);
            _playerData.coinsCollected++;
        } 

        if (other.CompareTag("Spin")) {

            Destroy(other.gameObject);
            _playerData.spinsCollected++;
        } 

        if (other.CompareTag("Gift")) {

            Destroy(other.gameObject);
            _playerData.giftsCollected++;
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
        defeat.Raise();
    }
}
