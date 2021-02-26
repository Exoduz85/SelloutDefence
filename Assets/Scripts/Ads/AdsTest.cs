using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

namespace Ads {
    public class AdsTest : MonoBehaviour, IUnityAdsListener {
        const string Interstitial = "Interstitial_Android";
        const string Rewarded = "Rewarded_Android";
        const string Banner = "Banner_Android";

        public Text counter;

        int _rewardedAdsWatched;
        int RewardedAdsWatched {
            get => this._rewardedAdsWatched;
            set {
                this._rewardedAdsWatched = value;
                this.counter.text = value.ToString();
            }
        }
        
        void Start()
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize("4023671", true);
        }

        public void ShowAd() => Advertisement.Show(Rewarded);
        
        public void ShowInterstitialAd() => Advertisement.Show(Interstitial);
        
        public void ShowBannerAd() => Advertisement.Show(Banner);

       
        public void OnUnityAdsReady(string placementId) {
            //Debug.Log("Ad is ready to be shown.");
        }
        
        public void OnUnityAdsDidStart(string placementId) {
            Debug.Log("Ad started.");
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) {
            
            Debug.Log("Placement ID in AdsDidFinish Method : " +placementId);
            if (showResult == ShowResult.Finished) {
                if(placementId == Rewarded)
                    this.RewardedAdsWatched++; 
                
                Debug.Log("Ad completed successfully");
            }
            else if (showResult == ShowResult.Failed) {
                Debug.Log("Nice try... NO REWARD!");
            }
        }
        public void OnUnityAdsDidError(string message) {
            Debug.LogError("Something went wrong with Unity Ad");
        }
    }
}
