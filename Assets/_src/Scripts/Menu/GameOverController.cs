using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace PedroAurelio.MKS
{
    public class GameOverController : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData gameData;

        [Header("Dependencies")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highscoreText;

        [Header("Settings")]
        [SerializeField] private float delayBeforeStop;

        private void Start()
        {
            StartCoroutine(StopTime());
            scoreText.text = gameData.SessionScore.ToString("00");
            highscoreText.text = gameData.Highscore.ToString("00");
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private IEnumerator StopTime()
        {
            yield return new WaitForSeconds(delayBeforeStop);
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}