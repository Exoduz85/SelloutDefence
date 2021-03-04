using System;
using UnityEngine;

namespace InAppPurchases {
    
    public class StoreAdapter : MonoBehaviour {
        
        IStoreHandler bestHandlerWeGotATM;
        
        void Start() {
            this.bestHandlerWeGotATM = FindObjectOfType<MyIAPManager>();
        }

        public void PurchaseGems(IStoreHandler storeHandler, string gemsID) {
            storeHandler.BuyGems(gemsID);   
        }
    }
}