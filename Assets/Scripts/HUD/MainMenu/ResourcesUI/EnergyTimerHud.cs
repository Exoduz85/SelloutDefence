using EventBrokerFolder;
using Player.Energy;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.MainMenu.ResourcesUI {
    public class EnergyTimerHud : MonoBehaviour {
        Text energyText;

        void Start() {
            this.energyText = GetComponent<Text>();
            EventBroker.Instance().SubscribeMessage<EventUpdateEnergyTime>(UpdateTimeText);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventUpdateEnergyTime>(UpdateTimeText);
        }

        void UpdateTimeText(EventUpdateEnergyTime remainingTime) {
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