using UnityEngine;

public class GameRulesLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] MiniGameData _miniGameData;
    [SerializeField] PlayerData[] _playersData;
    [Header("Events")]
    [SerializeField] IntEvent PlayerWonEvent;

    public void GameOverRule_Caller()
    {
        GameOverRule();
    }

    private void GameOverRule()
    {
        Debug.Log("yes");
        for (int i = 0; i < _playersData.Length; i++)
        {
            if (_playersData[i].score >= _miniGameData.playersGoal)
            {
                _miniGameData.gameIsOver = true;
                PlayerWonEvent.Raise(i);
            }
        }
    }
}