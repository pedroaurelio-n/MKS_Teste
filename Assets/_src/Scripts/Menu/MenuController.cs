using UnityEngine;
using UnityEngine.SceneManagement;

namespace PedroAurelio.MKS
{
    public class MenuController : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData gameData;

        public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
        public void SetSessionDuration(float seconds) => gameData.SetSessionDuration(seconds);
        public void SetEnemySpawnTime(int time) => gameData.SetEnemySpawnTime(time);
    }
}