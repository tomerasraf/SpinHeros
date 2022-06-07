using UnityEngine.SceneManagement;
using UnityEngine;

public class SpinInput : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] private VoidEvent SpinButtonPressed;

    public void SpinInputEventCall()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) {

            if (_playerData.spins >= 0)
            {
                SpinButtonPressed.Raise();
            }
        }


        if (SceneManager.GetActiveScene().buildIndex == 3) {
            SpinButtonPressed.Raise();
        }
    }
}
