using EventBrokerFolder;
using Player.Gems;
using UnityEngine;
using UnityEngine.UI;

namespace HUD {
    public class Gems : MonoBehaviour {
        [SerializeField] Text text;

        
        //TODO : Alex might know if this is an order of execution thing, or to do with the ISavable
        void Awake() {
            EventBroker.Instance().SubscribeMessage<EventUpdateGems>(UpdatePlayerGemsUI);
        }

        void UpdatePlayerGemsUI(EventUpdateGems eventUpdateGems) {
            this.text.text = eventUpdateGems.amount.ToString();
        }
    }
}
