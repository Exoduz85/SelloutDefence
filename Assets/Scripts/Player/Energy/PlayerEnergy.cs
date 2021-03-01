using EventBrokerFolder;
using Saving;
using UnityEngine;

namespace Player.Energy {
    public class PlayerEnergy : MonoBehaviour, ISavable {
        [SerializeField]
        Energy energy;

        void Start() {
            EventBroker.Instance().SubscribeMessage<EventEnergyAward>(UpdateEnergy);
            print(this.energy.RemainingEnergy);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventEnergyAward>(UpdateEnergy);
        }

        void UpdateEnergy(EventEnergyAward energyAward) {
            this.energy.RemainingEnergy += energyAward.EnergyToUpdate;
        }

        public object CaptureState()
            => this.energy.RemainingEnergy;


        public void RestoreState(object state) {
            this.energy.RemainingEnergy = (int) state;
        }
    }
}