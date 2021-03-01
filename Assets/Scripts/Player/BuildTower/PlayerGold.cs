using System;
using EventBrokerFolder;
using UnityEngine;

namespace Player.BuildTower {
    public class PlayerGold : MonoBehaviour {
        int gold;

        public int Gold {
            get => this.gold;
            set {
                this.gold = value;
                EventBroker.Instance().SendMessage(new EventGetGold(this.gold));
            }
        }

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