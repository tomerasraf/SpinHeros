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
        PlayerIsDead();
        PlayerWonByAttacking();
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

    private void PlayerIsDead() {
        for (int i = 0; i < _playersData.Length; i++)
        {
            if(_playersData[i].hearts <= 0)
            {
                _playersData[i].playerIsDead = true;
            }
        }
    }

    private void PlayerWonByAttacking() {

        _miniGameData.playerAlive = 4;

        for (int i = 0; i < _playersData.Length; i++)
        {
            if (_playersData[i].playerIsDead)
            {
                _miniGameData.playerAlive--;
            }
        }



        for (int i = 0; i < _playersData.Length; i++)
        {
            if (_miniGameData.playerAlive == 1)
            {
                if (!_playersData[i].playerIsDead) {

                   playerWon.Raise(i);
                   _miniGameData.gameIsOver = true;
                }
            }
        }
    }
}