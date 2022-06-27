using UnityEngine;
using UnityEngine.UI;

public class GameRulesLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] GameSettingsData _gameSettingData;
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] PlayerData[] _playersData;

    [Header("Events")]
    [SerializeField] IntEvent playerWon;
    [SerializeField] VoidEvent miniGameDisplayUI_Off;
    [SerializeField] VoidEvent playerWonSound;
    [SerializeField] VoidEvent winnerScreen;
    [SerializeField] VoidEvent defeatScreen;
 
    [Header("Spin Button")]
    [SerializeField] Button spinButton;

    [Header("UI")]
    [SerializeField] Image statusImage;

    [Header("Sprites")]
    [SerializeField] Sprite winner;
    [SerializeField] Sprite loser;

    private float counter = 0;
    private int previewsLoserSpinReward = 0;
    private int previewsWinnerSpinReward = 0;

    private void Start()
    {
        counter = 0;
    }

    private void Update()
    {
        playerScoreLimiter();
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
                counter++;
                if (counter == 1) {
                    CalculateMiniGameResults(i);
                    playerWonSound.Raise();
                    playerWon.Raise(i);
                    _miniGameData.gameIsOver = true;
                    spinButton.enabled = false;
                    miniGameDisplayUI_Off.Raise();
                    _gameSettingData.tutorialMode = false;
                }
            }
        }
    }

    private void CalculateMiniGameResults(int id) {

        

        if (_gameSettingData.tutorialMode)
        {
            previewsLoserSpinReward = _miniGameData.loserSpinPrize;
            previewsWinnerSpinReward = _miniGameData.winnerSpinPrize;
            _miniGameData.winnerSpinPrize = 50;
            _miniGameData.loserSpinPrize = 50;
        }
        else
        {
            _miniGameData.winnerSpinPrize = previewsWinnerSpinReward;
            _miniGameData.loserSpinPrize = previewsLoserSpinReward;
        }

        if (id == 0) {
            winnerScreen.Raise();
            statusImage.sprite = winner;
            _playersData[0].coins += _miniGameData.winnerPrize + (_playersData[0].amountPlayersAttacked * _miniGameData.attackBonus);
            _playersData[0].spins += _miniGameData.winnerSpinPrize;
        }
        else
        {
            defeatScreen.Raise();
            statusImage.sprite = loser;
            _playersData[0].coins += _miniGameData.loserPrize + (_playersData[0].amountPlayersAttacked * _miniGameData.attackBonus);
            _playersData[0].spins += _miniGameData.loserSpinPrize;
        }

        
    }
    private void PlayerIsDead() {
        for (int i = 0; i < _playersData.Length; i++)
        {
            if(_playersData[i].hearts <= 0)
            {
                _playersData[i].playerIsDead = true;
                if (i == 0) {
                    defeatScreen.Raise();
                    _miniGameData.gameIsOver = true;
                    miniGameDisplayUI_Off.Raise();
                }
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
                    if (i == 0) {
                        winnerScreen.Raise();
                    }
                    else
                    {
                        defeatScreen.Raise();
                    }

                    playerWon.Raise(i);
                   _miniGameData.gameIsOver = true;
                }
            }
        }
    }

    // checks that player score dosent go below 0
    private void playerScoreLimiter() {
        for (int i = 0; i < _playersData.Length; i++)
        {
            if (_playersData[i].score < 0) {
                _playersData[i].score = 0;
            }
        }
    }
}