using System;
using EventBrokerFolder;
using Player.Energy;
using UnityEngine;
using UnityEngine.UI;

namespace HUD {
    public class RemainingEnergyHud : MonoBehaviour {

        Text energyText;

        void Start() {
            this.energyText = GetComponent<Text>();
            EventBroker.Instance().SubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergyText);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergyText);
        }

        void UpdateEnergyText(UpdatePlayerEnergyEvent energyEvent) {
            this.energyText.text = energyEvent.PlayerEnergy.ToString();
        }
    }
}