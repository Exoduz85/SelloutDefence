using Core;
using EventBrokerFolder;
using UnityEngine;

namespace HUD.GameScene {
    public class RestartGame : MonoBehaviour {

        public void ButtonCallBack() {
            EventBroker.Instance().SendMessage(new EventLoadScene("GameScene"));
        }
    }
}