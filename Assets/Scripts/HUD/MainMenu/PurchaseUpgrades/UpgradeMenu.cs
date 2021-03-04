using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HUD.MainMenu.PurchaseUpgrades {
    public class UpgradeMenu : MonoBehaviour {
        
        [SerializeField] Text menuNameText;
        [SerializeField] RectTransform upgradeOptionsPanel;
        [SerializeField] GameObject upgradableMenuItemPrefab;

        public void UpdateName(string menuName) {
            this.menuNameText.text = menuName;
        }
        
        public void AddUpgrade(string upgradeName, int gemPrice, UnityAction onPurchase) {
            var instance = Instantiate(this.upgradableMenuItemPrefab, this.upgradeOptionsPanel);
            instance.GetComponent<UpgradableMenuItem>().Initialize(upgradeName, gemPrice, onPurchase);
            
        }
    }
}
