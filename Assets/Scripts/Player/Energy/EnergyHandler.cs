using EventBrokerFolder;
using UnityEngine;

namespace Player.Energy {
    public class EnergyHandler : MonoBehaviour {
        
        public void Energy(IPlayerEnergy playerEnergy) {
            
            EventBroker.Instance().SendMessage(new PlayerEnergyEvent(playerEnergy));

        }
    }
}