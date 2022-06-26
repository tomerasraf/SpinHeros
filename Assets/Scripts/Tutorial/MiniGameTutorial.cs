using System.Collections;
using UnityEngine;


public class MiniGameTutorial : MonoBehaviour
{
    [SerializeField] GameSettingsData _gameSettingsData;
    [SerializeField] GameObject miniGameTutorialPopout;

    IEnumerator Start()
    {
        if (_gameSettingsData.tutorialMode)
        {
            TutorialAnimationUtils.MassagePopoutAnimation(miniGameTutorialPopout.transform.localScale, miniGameTutorialPopout, 1);
            yield return new WaitForSeconds(1);

            Time.timeScale = 0;
            yield return null;
        }

    }

    public void GotItButton_Listener()
    {
        TutorialAnimationUtils.RemoveMassageAnimation(miniGameTutorialPopout, 0.5f);
        Time.timeScale = 1;
    }

}
