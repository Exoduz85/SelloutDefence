using EventBrokerFolder;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads {
    
    public class AdsManager : MonoBehaviour, IUnityAdsListener {
       
        const string Rewarded = "Rewarded_Android";
        const string AndroidGameID = "4023671";
        
        //const string Interstitial = "Interstitial_Android";
        //const string Banner = "Banner_Android";
        //void ShowInterstitialAd() => Advertisement.Show(Interstitial);
        //void ShowBannerAd() => Advertisement.Show(Banner);
        
        void Start()
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(AndroidGameID, true);
        }

        public void ShowAd() {
            if(Advertisement.IsReady(Rewarded))
                Advertisement.Show(Rewarded);
        }
        
        public void OnUnityAdsReady(string placementId) {
            //Debug.Log(placementId +" Ad is ready to be shown.");
        }
        
        public void OnUnityAdsDidStart(string placementId) {
            Debug.Log("Ad started.");
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) {
            if (showResult == ShowResult.Finished) {
                if(placementId == Rewarded) { //Logic for rewarded Ad watched
                    Debug.Log("Rewarded Ad watched");
                    EventBroker.Instance().SendMessage(new EventAdsRewardedCompleted());
                } 
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
