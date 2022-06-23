using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SpinInput : MonoBehaviour
{
    [SerializeField] SystemData _systemData;
    [SerializeField] PlayerData _playerData;
    [SerializeField] private VoidEvent SpinButtonPressed;
    [SerializeField] VoidEvent focuseOnWheel;
    [SerializeField] Button spinButton;

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

        spinButton.enabled = false;

        yield return new WaitForSeconds(2f);

        spinButton.enabled = true;

        if (_playerData.spins >= 0)
        {
            SpinButtonPressed.Raise();
        }

        yield return null;
    }
}
