using Player.Tower;
using UnityEngine;
using UnityEngine.UI;

namespace HUD {
    public class UpgradeSelectionGenerator : MonoBehaviour {
        [SerializeField] UpgradableTowers upgradableTowers;
        [SerializeField] GameObject upgradeSelectorPrefab;

        [SerializeField] GameObject upgradeMenu;
        [SerializeField] Transform canvas;
    
        void Start() {
            foreach (var tower in this.upgradableTowers.upgradableTowerDatas) {
                var instance = Instantiate(this.upgradeSelectorPrefab, this.transform);
                instance.GetComponent<UpgradeSelector>().Initialize(tower);
                instance.GetComponent<Button>().onClick.AddListener(() => GenerateUpgradeMenu(tower));
            }
        }

        void GenerateUpgradeMenu(UpgradableTowerData upgradableTowerData) {
            var instance = Instantiate(this.upgradeMenu, this.canvas);
            instance.GetComponent<UpgradeMenu>().UpdateName($"{upgradableTowerData.name} Upgrade");
            instance.GetComponent<UpgradeMenu>().AddUpgrade("Upgrade Damage", 1, () => upgradableTowerData.DmgUpgradeCount++);
            instance.GetComponent<UpgradeMenu>().AddUpgrade("Upgrade Range", 1, () => upgradableTowerData.RangeUpgradeCount++);
            instance.GetComponent<UpgradeMenu>().AddUpgrade("Upgrade Speed", 1, () => upgradableTowerData.SpeedUpgradeCount++);
        }
    }
}