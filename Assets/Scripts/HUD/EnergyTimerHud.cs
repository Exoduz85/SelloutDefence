using EventBrokerFolder;
using Player.Energy;
using UnityEngine;
using UnityEngine.UI;

namespace HUD {
    public class EnergyTimerHud : MonoBehaviour {
        Text energyText;

        void Start() {
            this.energyText = GetComponent<Text>();
            EventBroker.Instance().SubscribeMessage<UpdateEnergyTimeEvent>(UpdateTimeText);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<UpdateEnergyTimeEvent>(UpdateTimeText);
        }

        void UpdateTimeText(UpdateEnergyTimeEvent remainingTime) {
            this.energyText.text = $"{Minutes(remainingTime.Timer):00}:{Seconds(remainingTime.Timer):00}";
        }

        int Minutes(float timeRemaining) {
            return Mathf.FloorToInt(timeRemaining / 60);
        }

        int Seconds(float timeRemaining) {
            return Mathf.FloorToInt(timeRemaining % 60);
        }
    }
}