using System;
using Core;
using EventBrokerFolder;
using UnityEngine;

namespace Player.Energy {
    //TODO should persist through scenes?
    public class PlayerEnergy : MonoBehaviour {
        int RemainingEnergy { get; set; }

        DateTime lastLogin;
        DateTime now;

        void Start() {
            EventBroker.Instance().SubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergy);
        }

        void UpdateEnergy(UpdatePlayerEnergyEvent energy) {
            this.RemainingEnergy += energy.EnergyToUpdate;
            Debug.Log($"Remaining energy: {this.RemainingEnergy}");
        }
    }
}