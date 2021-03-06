using System;
using System.Collections.Generic;
using Enemy;
using EventBrokerFolder;
using UnityEngine;

namespace EnemySpawner {
    public class SpawnEnemies : MonoBehaviour {
        [SerializeField]
        private EnemyGroup[] _enemyWaves;
        [SerializeField]
        private bool shouldRepeat;

        private class WaveData {
            public readonly float SpawnInterval;
            public readonly int NumberOfEnemies;
            public readonly float EnemySpeed;
            public readonly GameObject EnemyPrefab;

            public WaveData(float spawnInterval, int noEnemies, float speed, GameObject prefab) {
                SpawnInterval = spawnInterval;
                NumberOfEnemies = noEnemies;
                EnemySpeed = speed;
                EnemyPrefab = prefab;
            }
        }

        private readonly List<WaveData> _wavesList = new List<WaveData>();

        private float spawnTimer;
        private int waveNumber;
        private int enemyInWaveNumber;
        
        void Awake() {
            foreach (var wave in _enemyWaves) {
                _wavesList.Add(new WaveData(wave.spawnInterval, wave.numberOfEnemies, wave.enemySpeed, wave.enemyPrefab));
            }
        }

        void Update() {
            //we have traversed all waves
            if (waveNumber >= _wavesList.Count) {
                if (this.shouldRepeat) {
                    this.waveNumber = 0;
                    this.enemyInWaveNumber = 0;
                }
                else {
                    return;
                }
            }

            if (isReadyToSpawn()) {
                SpawnEnemy();
            }

            //we have traversed all enemies in the current wave
            if (enemyInWaveNumber >= _wavesList[waveNumber].NumberOfEnemies){
                    waveNumber++;
                    enemyInWaveNumber = 0;
               
            }
        }

        private bool isReadyToSpawn() {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= _wavesList[waveNumber].SpawnInterval && enemyInWaveNumber < _wavesList[waveNumber].NumberOfEnemies) {
                spawnTimer = 0;
                return true;
            }

            return false;
        }

        private void SpawnEnemy() {
            var newEnemy = Instantiate(_wavesList[waveNumber].EnemyPrefab, transform.position, Quaternion.identity, transform);
            newEnemy.GetComponent<MoveEnemy>().speed = _wavesList[waveNumber].EnemySpeed;
            newEnemy.name += enemyInWaveNumber;
            enemyInWaveNumber++;
        }
    }
}