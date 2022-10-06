using UnityEngine;
using TMPro;
 
namespace PedroAurelio.MKS
{
    public class GameScore : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData gameData;

        [Header("Dependencies")]
        [SerializeField] private TextMeshProUGUI scoreText;

        private int _currentScore;

        private void Awake() => UpdateScore(0);

        public void UpdateScore(int score)
        {
            _currentScore += score;
            scoreText.text = _currentScore.ToString("00");
        }

        public void SetDataScore() => gameData.SetSessionScore(_currentScore);
    }
}