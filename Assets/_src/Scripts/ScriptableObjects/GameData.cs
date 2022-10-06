using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
    public class GameData : ScriptableObject
    {
        [field: SerializeField] public float SessionDuration { get; private set; }
        [field: SerializeField] public int EnemySpawnTime { get; private set; }
        [field: SerializeField] public int SessionScore { get; private set; }
        [field: SerializeField] public int Highscore { get; private set; }

        public void SetSessionDuration(float duration)
        {
            SessionDuration = duration;
        }

        public void SetEnemySpawnTime(int spawnTime)
        {
            EnemySpawnTime = spawnTime;
        }

        public void SetSessionScore(int newScore)
        {
            SessionScore = newScore;

            if (SessionScore > Highscore)
                Highscore = newScore;
        }
    }
}