using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
namespace PedroAurelio.MKS
{
    public class GameScore : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private TextMeshProUGUI scoreText;

        private int _currentScore;

        private void Awake() => UpdateScore(0);

        public void UpdateScore(int score)
        {
            _currentScore += score;
            scoreText.text = _currentScore.ToString("00");
        }

        public void TryToSetHighscore()
        {
            Debug.Log($"set highscore");
            if (_currentScore > gameData.Highscore)
                gameData.SetHighscore(_currentScore);
        }
    }
}