using EventBrokerFolder;
using Saving;
using UnityEngine;

namespace Player.Energy {
    //TODO should persist through scenes?
    public class PlayerEnergy : MonoBehaviour, ISavable {
        [SerializeField]
        int maxEnergy;

        int RemainingEnergy { get; set; }


        void Start() {
            EventBroker.Instance().SubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergy);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergy);
        }

        void UpdateEnergy(UpdatePlayerEnergyEvent energy) {
            Mathf.Clamp(this.RemainingEnergy += energy.EnergyToUpdate, 0, this.maxEnergy);
            EventBroker.Instance().SendMessage(new UpdatePlayerEnergyEvent(this.RemainingEnergy));
            Debug.Log($"Remaining energy: {this.RemainingEnergy}");
        }

        public object CaptureState()
            => this.RemainingEnergy;


        public void RestoreState(object state)
            => this.RemainingEnergy = (int) state;
    }
}