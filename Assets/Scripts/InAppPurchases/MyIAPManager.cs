using System;
using UnityEngine;
using UnityEngine.Purchasing;

namespace InAppPurchases {
    public class MyIAPManager : MonoBehaviour, IStoreListener {
        
        //All info in this script comes from these sources.
        
        //https://docs.unity3d.com/Manual/UnityIAPGoogleConfiguration.html 
        //https://learn.unity.com/tutorial/unity-iap#5c7f8528edbc2a002053b46e
    
        private IStoreController controller; // Overall Purchasing system, configured with products for this application.
        private IExtensionProvider extensions; // Store specific subsystem, for accessing device-specific store features.
        
        private bool IsInitialized => this.controller != null && this.extensions != null;
        
        //Here we declare the in-game products we want
        string purchaseGems10 = "purchase_gems_10";
        string purchaseGems20 = "purchase_gems_20";
        string purchaseGems40 = "purchase_gems_40";
        
        void Start()
        {
            // If we haven't set up the Unity Purchasing reference
            if (controller == null)
            {
                // Begin to configure our connection to Purchasing
                InitializePurchasing();
            }
        }

        public void InitializePurchasing() {
            
            if (IsInitialized) return;
            
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(this.purchaseGems10, ProductType.NonConsumable);
            builder.AddProduct(this.purchaseGems20, ProductType.NonConsumable);
            builder.AddProduct(this.purchaseGems40, ProductType.NonConsumable);
            UnityPurchasing.Initialize (this, builder);

            #region FYI
            //There are 3 types of Items to add to the store
            //Consumables - Can not be rebought, such as RemoveAds for eg.
            //NonConsumables - Can be purchased multiple times
            //Subscription - duh
            
            //Example of how to do it for multiple Platforms
            // builder.AddProduct("100_gold_coins", ProductType.Consumable, new IDs
            // {
            //     {"100_gold_coins_google", GooglePlay.Name},
            //     {"100_gold_coins_mac", MacAppStore.Name}
            // });
            #endregion
        }

        /// <summary>
        /// Called when Unity IAP is ready to make purchases.
        /// </summary>
        public void OnInitialized (IStoreController controller, IExtensionProvider extensions)
        {
            this.controller = controller;
            this.extensions = extensions; 
            
            Debug.Log("Store Initialization Complete.");
        }
    
        /// <summary>
        /// Called when a purchase completes.
        ///
        /// May be called at any time after OnInitialized().
        /// </summary>
        public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs e)
        {
            if (String.Equals(e.purchasedProduct.definition.id, this.purchaseGems10, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", e.purchasedProduct.definition.id));
                // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
                
            }
            else if (String.Equals(e.purchasedProduct.definition.id, this.purchaseGems20, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", e.purchasedProduct.definition.id));
                
            }
            else if (String.Equals(e.purchasedProduct.definition.id, this.purchaseGems40, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", e.purchasedProduct.definition.id));
            }
            else 
            {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", e.purchasedProduct.definition.id));
            }

            // Return a flag indicating whether this product has completely been received, or if the application needs 
            // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
            // saving purchased products to the cloud, and when that save is delayed. 
            return PurchaseProcessingResult.Complete;
        }
        public void OnInitializeFailed (InitializationFailureReason error)
        {
            Debug.Log("Initialization Failed. Perhaps check your internet connection?");
        }
        public void OnPurchaseFailed (Product i, PurchaseFailureReason p)
        {
            Debug.Log("Purchase Failed");
        }
    }
}