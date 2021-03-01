using Core;
using EventBrokerFolder;
using Player.Energy;
using UnityEngine;

namespace HUD {
    public class PlayGame : MonoBehaviour {
        public void Play(string sceneToLoad) {
            EventBroker.Instance().SendMessage(new EventLoadScene(sceneToLoad));
        }

        public void ConsumeEnergy(Energy energy) {
            energy.RemainingEnergy--;
            print(energy.RemainingEnergy);
        }
    }
}