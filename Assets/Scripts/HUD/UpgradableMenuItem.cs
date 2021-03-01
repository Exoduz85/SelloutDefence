using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HUD {
    public class UpgradableMenuItem : MonoBehaviour {
    
        [SerializeField] Text titleText;
        [SerializeField] Text priceText;

        public void Initialize(string title, float price, UnityAction onPurchase) {
            this.titleText.text = title;
            this.priceText.text = price.ToString("0,00");
            GetComponent<Button>().onClick.AddListener(onPurchase);
        }
    }
}