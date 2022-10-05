using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
 
namespace PedroAurelio.MKS
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highscoreText;

        private void Start()
        {
            Time.timeScale = 0f;
            scoreText.text = gameData.SessionScore.ToString("00");
            highscoreText.text = gameData.Highscore.ToString("00");
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}