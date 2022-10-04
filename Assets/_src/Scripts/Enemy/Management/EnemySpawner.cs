using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private List<Enemy> enemyPrefabList;
        [SerializeField] private List<Transform> spawnPositions;

        private float  _spawnTime;
        private WaitForSeconds _waitForSpawnTime;

        private void Awake()
        {
            if (gameData.EnemySpawnTime != default)
                _spawnTime = gameData.EnemySpawnTime;
            else
                _spawnTime = 3f;
            
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

                var player = Player.PlayerObject;
                var randomSpawn = spawnPositions[Random.Range(0, spawnPositions.Count)];
                enemy.Initialize(player.transform, randomSpawn.position);
            }
        }
    }
}