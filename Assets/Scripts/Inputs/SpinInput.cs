using UnityEngine;
using UnityEngine.SceneManagement;

public class SpinInput : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] private VoidEvent SpinButtonPressed;
    [SerializeField] VoidEvent focuseOnWheel;

    public void SpinInputEventCall()
    {
      
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            focuseOnWheel.Raise();

            if (_playerData.spins >= 0)
            {
                SpinButtonPressed.Raise();
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
}
