using System;
using EventBrokerFolder;
using Player.Energy;
using UnityEngine;
using UnityEngine.UI;

namespace HUD {
    public class RemainingEnergyHud : MonoBehaviour {

        [SerializeField]
        PlayerEnergy playerEnergy;
        Text energyText;

        void Start() {
            this.energyText = GetComponent<Text>();
        }

        void Update() {
            UpdateEnergyText();
        }

        void UpdateEnergyText() {
            this.energyText.text = this.playerEnergy.RemainingEnergy.ToString();
        }
    }
}