using UnityEngine;
using UnityEngine.Tilemaps;

namespace Player.Tower{
    [CreateAssetMenu(fileName = "New Tower Data", menuName = "Tower Data/New tower data")]
    public class TowerData : ScriptableObject {
        public string towerType;
        public float attackSpeed;
        public float attackRange;
        public float damage;
        public int costRequiredToBuy;
        public TileBase towerAddon;
        public float projectileSpeed;
        public GameObject projectilePrefab;
    }
}