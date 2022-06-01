using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.UI.UI.Mini_Game
{
    public class ScorePopout : MonoBehaviour
    {
        [SerializeField] PlayerData[] _playerData;
        [SerializeField] GameObject[] scoreText;

        [Header("Events")]
        [SerializeField] VoidEvent miniGameIsOver;

        private Vector3 popoutStartPosition;

        private void Start()
        {
            for (int i = 0; i < scoreText.Length; i++)
            {
                scoreText[i].GetComponent<TextMeshProUGUI>().DOFade(0, 0);
            }
        }

        public void ScorePopout_Listener(int playerID)
        {

            if (_playerData[playerID].currentPrize < 0)
            {
                scoreText[playerID].GetComponent<TextMeshProUGUI>().text = _playerData[playerID].currentPrize.ToString();
            }
            else
            {
                scoreText[playerID].GetComponent<TextMeshProUGUI>().text = "+ " + _playerData[playerID].currentPrize.ToString();

            }

            popoutStartPosition = scoreText[playerID].transform.position;
            scoreText[playerID].transform.DOMoveY(popoutStartPosition.y - 800, 2f);

            scoreText[playerID].GetComponent<TextMeshProUGUI>().DOFade(1, 0);

            scoreText[playerID].transform.DOMoveY(popoutStartPosition.y, 2f);
            scoreText[playerID].GetComponent<TextMeshProUGUI>().DOFade(0, 2);


        }

    }
}