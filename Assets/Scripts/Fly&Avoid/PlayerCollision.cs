using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData _playerData;

    [Header("Events")]
    [SerializeField] VoidEvent updateUI;
    [SerializeField] VoidEvent damageBlink;
    [SerializeField] VoidEvent asteroidExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            if (_playerData.hearts < 0) { return; }
            _playerData.hearts--;
            updateUI.Raise();
            damageBlink.Raise();
            transform.GetComponent<Animator>().SetBool("PlayerGotHit", true);
            StartCoroutine(immuneTimer());
        }
        
        if (other.CompareTag("Asteroid")) {
            asteroidExplosion.Raise();
        }
    }

    IEnumerator immuneTimer() {

        while (_playerData.playerIsImmuneTime > 0) {

            transform.GetComponent<BoxCollider>().enabled = false;
            _playerData.playerIsImmuneTime -= Time.deltaTime;
            yield return null;
        }
        transform.GetComponent<BoxCollider>().enabled = true;
        yield return null;
    }


}
