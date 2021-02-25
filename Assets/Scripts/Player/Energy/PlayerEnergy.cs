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
            private set => this.remainingEnergy = Mathf.Clamp(value, 0, this.maxEnergy);
        }


        void Start() {
            EventBroker.Instance().SubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergy);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergy);
        }

        void UpdateEnergy(UpdatePlayerEnergyEvent energy) {
            this.RemainingEnergy += energy.EnergyToUpdate;
            Debug.Log($"Remaining energy: {this.RemainingEnergy}");
        }

        public object CaptureState()
            => this.RemainingEnergy;


        public void RestoreState(object state)
            => this.RemainingEnergy = (int) state;
    }
}