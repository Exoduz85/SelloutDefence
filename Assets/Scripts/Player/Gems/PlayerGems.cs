using System;
using EventBrokerFolder;
using Saving;
using UnityEngine;

namespace Player.Gems {
    public class PlayerGems : MonoBehaviour, ISavable {
        int totGems;

        int TotalGems {
            get => this.totGems;
            set {
                this.totGems = value;
                EventBroker.Instance().SendMessage(new EventUpdateGems(this.totGems));
                print("Updating Player Gems: " +this.totGems);
            }
        }
        
        public bool CanAfford(int cost) => cost <= this.TotalGems;

        void Start() {
            EventBroker.Instance().SubscribeMessage<EventIncrementGems>(IncrementGems);
        }
        
        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventIncrementGems>(IncrementGems);
        }

        void IncrementGems(EventIncrementGems gems) {
            this.TotalGems += gems.amount;
        }

        public object CaptureState() {
            return this.TotalGems;
        }

        public void RestoreState(object state) {
            TotalGems = (int)state;
        }

        
    }
}