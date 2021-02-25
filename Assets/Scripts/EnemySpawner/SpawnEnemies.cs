using Enemy;
using EnemySpawner;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour{
    [SerializeField] private EnemyWave _enemyWaves;

    private float _spawnInterval;
    private int _numberOfEnemies;
    private float _enemySpeed;
    private GameObject _enemyPrefab;

    private float spawnTimer;
    private int enemyNumber;

    void Start(){
        _spawnInterval = _enemyWaves.spawnInterval;
        _numberOfEnemies = _enemyWaves.numberOfEnemies;
        _enemySpeed = _enemyWaves.enemySpeed;
        _enemyPrefab = _enemyWaves.enemyPrefab;
    }
    
    void Update(){
        spawnTimer += Time.deltaTime;
        
        if (enemyNumber >= _numberOfEnemies)
            return;
        if (spawnTimer >= _spawnInterval){
            spawnTimer = 0;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy(){
        Debug.Log($"spawning new enemy: {enemyNumber+1}");
        var newEnemy = Instantiate(_enemyPrefab);
        newEnemy.GetComponent<MoveEnemy>().speed = _enemySpeed;
        enemyNumber++;
        
    }
}
