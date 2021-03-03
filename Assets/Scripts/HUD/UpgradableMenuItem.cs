using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HUD {
    public class UpgradableMenuItem : MonoBehaviour {
    
        [SerializeField] Text titleText;
        [SerializeField] Text priceText;

        public void Initialize(string title, int price, UnityAction onPurchase) {
            this.titleText.text = title;
            this.priceText.text = $"{price.ToString()} Gems"; 
            GetComponent<Button>().onClick.AddListener(onPurchase);
            GetComponent<Button>().onClick.AddListener(() => Destroy(FindObjectOfType<UpgradeMenu>().gameObject));
        }
    }
}