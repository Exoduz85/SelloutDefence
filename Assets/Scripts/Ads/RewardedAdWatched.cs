using System;
using EventBrokerFolder;
using Player.Gems;
using UnityEngine;

namespace Ads {
    public class RewardedAdWatched : MonoBehaviour {
        void Start() {
            EventBroker.Instance().SubscribeMessage<EventAdsRewardedCompleted>(AddGem);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventAdsRewardedCompleted>(AddGem);
        }

        void AddGem(EventAdsRewardedCompleted e) {
            EventBroker.Instance().SendMessage(new EventIncrementGems(1));
            
        }
    }
}