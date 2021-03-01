using HUD;
using UnityEngine;

namespace Player.Tower {
    [CreateAssetMenu(fileName = "New Tower Upgrade Data", menuName = "Tower Data/Tower Upgrade Data")]
    public class UpgradableTowerData : ScriptableObject {
        public float damageUpgrade;
        public float attackSpeedUpgrade;
        public float specialUpgrade;

        // public GameObject upgradeMenu;
        //
        // public void GenerateUpgradeMenu() {
        //     var instance = Instantiate(this.upgradeMenu, FindObjectOfType<Canvas>().gameObject.transform);
        //     var upgradeMenuToAddItemsTo = instance.GetComponent<UpgradeMenu>();
        //
        //     upgradeMenuToAddItemsTo.AddUpgrade("Damage Upgrade", this.damageUpgrade);
        //     upgradeMenuToAddItemsTo.AddUpgrade("Attack Speed Upgrade", this.attackSpeedUpgrade);
        //     upgradeMenuToAddItemsTo.AddUpgrade("Special Upgrade", this.specialUpgrade); 
        //     
        // }
    }
}
