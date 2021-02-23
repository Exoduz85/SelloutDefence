using EventBrokerFolder;
using UnityEngine;

namespace Player.Energy {
    //TODO should persist through scenes?
    public class PlayerEnergy : MonoBehaviour {
        int RemainingEnergy { get; set; }

        void Start() {
            EventBroker.Instance().SubscribeMessage<PlayerEnergyEvent>(Energy);
        }

        void Energy(PlayerEnergyEvent energy) {
            this.RemainingEnergy += energy.Energy.AmountToUpdate();
            Debug.Log($"Remaining energy: {this.RemainingEnergy}");
        }
    }
}