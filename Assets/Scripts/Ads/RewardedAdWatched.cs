using System;
using EventBrokerFolder;
using UnityEngine;

namespace Ads {
    public class RewardedAdWatched : MonoBehaviour {
        void Start() {
            EventBroker.Instance().SubscribeMessage<EventAdsRewardedCompleted>(AddGem);
        }

        void AddGem(EventAdsRewardedCompleted e) {
            //EventBroker.Instance().SendMessage(new Event);
        }
    }
}