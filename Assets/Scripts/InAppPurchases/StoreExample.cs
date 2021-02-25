using System;
using UnityEngine;
using UnityEngine.Purchasing;


namespace InAppPurchases {
    public class StoreExample : IStoreListener{
        
        bool IsInitialized => m_StoreController != null && m_StoreExtensionProvider != null;
        
        private static IStoreController m_StoreController;          // The Unity Purchasing system.
        private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

        string purchaseGems10 = "gems_purchase_10";
        string purchaseGems20 = "gems_purchase_20";
        string purchaseGems40 = "gems_purchase_40";

        public void InitializePurchasing() {
            if (IsInitialized) return;
            
            
        }
        
        
                
        public void OnInitializeFailed(InitializationFailureReason error) {
            throw new System.NotImplementedException();
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent) {
            throw new System.NotImplementedException();
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
            throw new System.NotImplementedException();
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
            throw new System.NotImplementedException();
        }
    }

    public class MyIAPManager : IStoreListener {
    
        private IStoreController controller;
        private IExtensionProvider extensions;
    
        public MyIAPManager () {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct("100_gold_coins", ProductType.Consumable, new IDs
            {
                {"100_gold_coins_google", GooglePlay.Name},
                {"100_gold_coins_mac", MacAppStore.Name}
            });
    
            UnityPurchasing.Initialize (this, builder);
        }
    
        /// <summary>
        /// Called when Unity IAP is ready to make purchases.
        /// </summary>
        public void OnInitialized (IStoreController controller, IExtensionProvider extensions)
        {
            this.controller = controller;
            this.extensions = extensions;
        }
    
        /// <summary>
        /// Called when Unity IAP encounters an unrecoverable initialization error.
        ///
        /// Note that this will not be called if Internet is unavailable; Unity IAP
        /// will attempt initialization until it becomes available.
        /// </summary>
        public void OnInitializeFailed (InitializationFailureReason error)
        {
        }
    
        /// <summary>
        /// Called when a purchase completes.
        ///
        /// May be called at any time after OnInitialized().
        /// </summary>
        public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs e)
        {
            return PurchaseProcessingResult.Complete;
        }
    
        /// <summary>
        /// Called when a purchase fails.
        /// </summary>
        public void OnPurchaseFailed (Product i, PurchaseFailureReason p)
        {
        }
    }
}