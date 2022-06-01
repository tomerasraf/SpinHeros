using UnityEngine.SceneManagement;
using UnityEngine;

public class SpinInput : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] private VoidEvent SpinButtonPressed;

    public void SpinInputEventCall()
    {
        if (_playerData.spins > -1) { 
            SpinButtonPressed.Raise();
        }

        if (SceneManager.GetActiveScene().buildIndex == 3) {
            SpinButtonPressed.Raise();
        }
    }
}
