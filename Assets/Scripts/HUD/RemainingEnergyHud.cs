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
            EventBroker.Instance().SubscribeMessage<EventEnergyChange>(UpdateEnergyText);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventEnergyChange>(UpdateEnergyText);
        }

        void UpdateEnergyText(EventEnergyChange energyAward) {
            this.energyText.text = energyAward.RemainingEnergy.ToString();
        }
    }
}