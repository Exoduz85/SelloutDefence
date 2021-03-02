using EventBrokerFolder;
using Player.Gems;
using UnityEngine;

namespace InAppPurchases {
    public class IAPTestScript : MonoBehaviour, IStoreHandler {
        
        const string purchaseGems10 = "purchase_gems_10";
        const string purchaseGems20 = "purchase_gems_20";
        const string purchaseGems40 = "purchase_gems_40";

        public void BuyGems(string gemPackage) {
            switch (gemPackage) {
                case purchaseGems10:
                    EventBroker.Instance().SendMessage(new EventGemsPurchased(10));
                    EventBroker.Instance().SendMessage(new EventIncrementGems(10));
                    break;
                case purchaseGems20:
                    EventBroker.Instance().SendMessage(new EventGemsPurchased(20));
                    EventBroker.Instance().SendMessage(new EventIncrementGems(20));
                    break;
                case purchaseGems40:
                    EventBroker.Instance().SendMessage(new EventGemsPurchased(40));
                    EventBroker.Instance().SendMessage(new EventIncrementGems(40));
                    break;
                default:
                    break;
            }
        }
    }
    public class EventGemsPurchased {
        int quantity;

        public EventGemsPurchased(int quantity) {
            this.quantity = quantity;
        }
    }
}

public interface IStoreHandler {
    public void BuyGems(string gemPackage);
}

