using UnityEngine;

namespace EnemySpawner{
    [CreateAssetMenu]
    public class EnemyGroup : ScriptableObject{
        [SerializeField]public GameObject enemyPrefab;
        [SerializeField]public int numberOfEnemies;
        [SerializeField]public float spawnInterval;
        [SerializeField]public float enemySpeed;

    }
}
