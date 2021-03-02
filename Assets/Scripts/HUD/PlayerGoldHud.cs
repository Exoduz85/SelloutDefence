using System;
using EventBrokerFolder;
using Player.BuildTower;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace HUD {
    public class PlayerGoldHud : MonoBehaviour {
        Text goldHud;

        void Awake() {
            this.goldHud = GetComponent<Text>();
            EventBroker.Instance().SubscribeMessage<EventGetGold>(UpdateGold);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventGetGold>(UpdateGold);
        }

        void UpdateGold(EventGetGold gold) {
            this.goldHud.text = gold.amountOfGold.ToString();
        }
    }
}