using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpinInput : MonoBehaviour
{
    [SerializeField] SystemData _systemData;
    [SerializeField] PlayerData _playerData;
    [SerializeField] private VoidEvent SpinButtonPressed;
    [SerializeField] VoidEvent focuseOnWheel;

    public void SpinInputEventCall()
    {

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            focuseOnWheel.Raise();

            if (!_systemData.cameraIsFocusedOnWheel) {
                StartCoroutine(DealyAction());
            }
            else
            { 
                if (_playerData.spins >= 0)
                {
                    SpinButtonPressed.Raise();
                }
            } 
        }


        if (SceneManager.GetActiveScene().buildIndex == 3)
        {

            if (_playerData.playerIsDead)
            {
                return;
            }
            SpinButtonPressed.Raise();
        }
    }

    IEnumerator DealyAction() {

        yield return new WaitForSeconds(2f);

        if (_playerData.spins >= 0)
        {
            SpinButtonPressed.Raise();
        }

        yield return null;
    }
}
