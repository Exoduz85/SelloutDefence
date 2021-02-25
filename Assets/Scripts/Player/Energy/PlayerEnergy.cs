using EventBrokerFolder;
using Saving;
using UnityEngine;

namespace Player.Energy {
    public class PlayerEnergy : MonoBehaviour, ISavable {
        [SerializeField]
        int maxEnergy;

        int remainingEnergy;

        int RemainingEnergy {
            get => this.remainingEnergy;
            set {
                this.remainingEnergy = Mathf.Clamp(value, 0, this.maxEnergy);
                EventBroker.Instance().SendMessage(new EventEnergyChange(this.RemainingEnergy));
            }
        }


        void Start() {
            EventBroker.Instance().SubscribeMessage<EventEnergyAward>(UpdateEnergy);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventEnergyAward>(UpdateEnergy);
        }

        void UpdateEnergy(EventEnergyAward energyAward) {
            this.RemainingEnergy += energyAward.EnergyToUpdate;
        }

        public object CaptureState()
            => this.RemainingEnergy;


        public void RestoreState(object state) {
            this.RemainingEnergy = (int) state;
        }
    }
}