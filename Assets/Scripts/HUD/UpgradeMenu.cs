using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HUD {
    public class UpgradeMenu : MonoBehaviour {
        
        [SerializeField] Text menuNameText;
        [SerializeField] RectTransform upgradeOptionsPanel;
        [SerializeField] GameObject upgradableMenuItemPrefab;

        public void UpdateName(string menuName) {
            this.menuNameText.text = menuName;
        }
        
        public void AddUpgrade(string upgradeName, float price, UnityAction onPurchase) {
            var instance = Instantiate(this.upgradableMenuItemPrefab, this.upgradeOptionsPanel);
            instance.GetComponent<UpgradableMenuItem>().Initialize(upgradeName, price, onPurchase);
            
        }
    }
}