using Player.Tower;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.MainMenu.PurchaseUpgrades {
    public class UpgradeSelector : MonoBehaviour
    {
        public void Initialize(UpgradableTowerData upgradableTowerData) {
            GetComponent<Image>().sprite = upgradableTowerData.sprite;
        
        }
    }
}
