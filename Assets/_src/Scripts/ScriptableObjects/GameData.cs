using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 
namespace PedroAurelio.MKS
{
    [CustomEditor(typeof(GameData))]
    public class GameDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var gameData = (GameData)target;

            if (GUILayout.Button("Reset Highscore"))
            {
                gameData.SetHighscore(0);
            }
        }
    }

    [CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
    public class GameData : ScriptableObject
    {
        public float SessionDuration { get; private set; }
        public int EnemySpawnRate { get; private set; }
        public int Highscore { get; private set; }

        public void SetSessionDuration(float duration)
        {
            SessionDuration = duration;
        }

        public void SetEnemySpawnTime(int spawnRate)
        {
            EnemySpawnRate = spawnRate;
        }

        public void SetHighscore(int newScore)
        {
            Highscore = newScore;
        }
    }
}