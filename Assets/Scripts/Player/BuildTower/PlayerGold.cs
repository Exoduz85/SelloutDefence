using System;
using EventBrokerFolder;
using UnityEngine;

namespace Player.BuildTower {
    public class PlayerGold : MonoBehaviour {
        public int Gold { get; set; }

        void Start() {
            this.Gold = 30;
            EventBroker.Instance().SubscribeMessage<EventUpdatePlayerGold>(UpdateGold);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventUpdatePlayerGold>(UpdateGold);
        }

        void UpdateGold(EventUpdatePlayerGold gold) {
            this.Gold += gold.amount;
        }
    }
}