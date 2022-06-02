using UnityEngine;
using UnityEngine.UI;

public class GameRulesLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField]
    PlayerData[] _playersData;

    [Header("Events")]
    [SerializeField] IntEvent playerWon;
    [SerializeField] VoidEvent miniGameDisplayUI_Off;
 
    [Header("Spin Button")]
    [SerializeField] Button spinButton;


    private void Update()
    {
        GameOverRule();
    }

    private void GameOverRule()
    {
        for (int i = 0; i < _playersData.Length; i++)
        {
            if (_playersData[i].score >= _miniGameData.playersGoal)
            {
                playerWon.Raise(i);
                _miniGameData.gameIsOver = true;
                spinButton.enabled = false;
                miniGameDisplayUI_Off.Raise();
            }
        }
    }
}