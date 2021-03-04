using UnityEngine;

namespace Player.Tower {
    [CreateAssetMenu(fileName = "New Tower Upgrade Data", menuName = "Tower Data/Tower Upgrade Data")]
    public class UpgradableTowerData : ScriptableObject {
        
        public Sprite sprite;
        public TowerData towerData;
        public float damageUpgrade;
        public float rangeUpgrade;
        public float attackSpeedUpgrade;

        int _dmgUpgrade;
        public int DmgUpgradeCount {
            get => this._dmgUpgrade == 0 ? 1 : this._dmgUpgrade;
            set => this._dmgUpgrade = value;
        }

        int _rangeUpgrade;
        public int RangeUpgradeCount {
            get => this._rangeUpgrade == 0 ? 1 : this._rangeUpgrade;
            set => this._rangeUpgrade = value;
        }

        int _speedUpgrade;
        public int SpeedUpgradeCount {
            get => this._speedUpgrade == 0 ? 1 : this._speedUpgrade;
            set => this._speedUpgrade = value;
        }

        public void RestoreStats(int[] stats) {
            this.DmgUpgradeCount = stats[0];
            this.RangeUpgradeCount = stats[1];
            this.SpeedUpgradeCount = stats[2];
        }
    }
}
