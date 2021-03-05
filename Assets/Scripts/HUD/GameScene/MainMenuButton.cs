using Core;
using EventBrokerFolder;
using UnityEngine;

namespace HUD.GameScene {
    public class MainMenuButton : MonoBehaviour {
        
        public void ButtonCallBack() { 
            EventBroker.Instance().SendMessage(new EventLoadScene("MainMenu"));
        }
    }
}