using System;
using EventBrokerFolder;
using UnityEngine;

namespace Player.Gems {
    public class PlayerGems : MonoBehaviour {
        int totGems;

        int TotalGems {
            get => this.totGems;
            set {
                this.totGems = value;
                EventBroker.Instance().SendMessage(new EventUpdateGems(this.totGems));
                print("Updating Player Gems: " +this.totGems);
            }
        }

        void Start() {
            EventBroker.Instance().SubscribeMessage<EventIncrementGems>(IncrementGems);
        }
        
        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventIncrementGems>(IncrementGems);
        }

        void IncrementGems(EventIncrementGems gems) {
            this.TotalGems += gems.amount;
        }
    }
}