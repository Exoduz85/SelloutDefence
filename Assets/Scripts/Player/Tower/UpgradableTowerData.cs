using EventBrokerFolder;
using UnityEngine;

namespace Player.Tower {
    [CreateAssetMenu(fileName = "New Tower Upgrade Data", menuName = "Tower Data/Tower Upgrade Data")]
    public class UpgradableTowerData : ScriptableObject {
        
        public float damageUpgrade;
        public float rangeUpgrade;
        public float attackSpeedUpgrade;

        public Sprite sprite;

        public void UpgradeDamage() {
            Debug.Log("Ooh yeah, upgrade me harder!");
        }
    }
}
