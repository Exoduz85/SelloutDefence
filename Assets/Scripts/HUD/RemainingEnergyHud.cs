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
            EventBroker.Instance().SubscribeMessage<PlayerEnergyChangeEvent>(UpdateEnergyText);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<PlayerEnergyChangeEvent>(UpdateEnergyText);
        }

        void UpdateEnergyText(PlayerEnergyChangeEvent energyAwardEvent) {
            this.energyText.text = energyAwardEvent.RemainingEnergy.ToString();
        }
    }
}