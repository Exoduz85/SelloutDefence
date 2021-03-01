using Core;
using EventBrokerFolder;
using UnityEngine;

namespace HUD {
    public class LoadScene : MonoBehaviour {
        public void LoadSceneEvent(string sceneToLoad) {
            EventBroker.Instance().SendMessage(new EventLoadScene(sceneToLoad));
        }
    }
}