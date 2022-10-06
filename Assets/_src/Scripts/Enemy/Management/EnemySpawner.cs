using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData gameData;
        
        [Header("Dependencies")]
        [SerializeField] private List<Enemy> enemyPrefabList;
        [SerializeField] private List<Transform> spawnPositions;

        private float  _spawnTime;
        private WaitForSeconds _waitForSpawnTime;

        private void Awake()
        {
            _spawnTime = gameData.EnemySpawnTime;
            
            _waitForSpawnTime = new WaitForSeconds(_spawnTime);

            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return _waitForSpawnTime;

                var randomEnemy = enemyPrefabList[Random.Range(0, enemyPrefabList.Count)];
                var enemy = Instantiate(randomEnemy, transform);

                var player = LevelDependencies.Player;
                var randomSpawn = spawnPositions[Random.Range(0, spawnPositions.Count)];
                enemy.Initialize(player.transform, randomSpawn.position);
            }
        }
    }
}