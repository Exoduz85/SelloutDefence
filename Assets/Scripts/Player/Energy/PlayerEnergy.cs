using System;
using EventBrokerFolder;
using Saving;
using UnityEngine;

namespace Player.Energy {
    //TODO should persist through scenes?
    public class PlayerEnergy : MonoBehaviour, ISavable {
        [SerializeField]
        int maxEnergy;

        int remainingEnergy;

        public int RemainingEnergy {
            get => this.remainingEnergy;
            private set {
                this.remainingEnergy = Mathf.Clamp(value, 0, this.maxEnergy);
                EventBroker.Instance().SendMessage(new PlayerEnergyChangeEvent(this.RemainingEnergy));
            }
        }


        void Start() {
            EventBroker.Instance().SubscribeMessage<PlayerEnergyAwardEvent>(UpdateEnergy);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<PlayerEnergyAwardEvent>(UpdateEnergy);
        }

        void UpdateEnergy(PlayerEnergyAwardEvent energyAward) {
            this.RemainingEnergy += energyAward.EnergyToUpdate;
            //Debug.Log($"Remaining energy: {this.RemainingEnergy}");
        }

        public object CaptureState()
            => this.RemainingEnergy;


        public void RestoreState(object state) {
            this.RemainingEnergy = (int) state;
        }
    }
}