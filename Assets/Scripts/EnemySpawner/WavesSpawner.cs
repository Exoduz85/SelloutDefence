
using System.Collections;
using Enemy;
using EventBrokerFolder;
using UnityEngine;

public class WavesSpawner : MonoBehaviour{
    [SerializeField] private GameObject[] enemyWaves;
    private int waveNumber;

    private void Start(){
        EventBroker.Instance().SubscribeMessage<EventStartWave>(SpawnNextWave);
    }

    private void SpawnNextWave(EventStartWave wave){
        if (wave.startSpawnEnemies == false)
            return;
        if (waveNumber >= enemyWaves.Length)
            return;
        Instantiate(enemyWaves[waveNumber], transform.position, Quaternion.identity, transform);
        waveNumber++;
    }
}
