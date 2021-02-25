using EventBrokerFolder;
using Saving;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Energy {
    public class RefillTime : MonoBehaviour, ISavable {
        float myTime;
        float timeRemaining;
        public Text energyText;
        public float energyFillCd = 120;


        void Start() {
            this.timeRemaining = this.energyFillCd;
            print(this.timeRemaining);
        }

        void Update() {
            this.myTime += Time.deltaTime;
            if (this.myTime >= 1) {
                this.timeRemaining--;
                EventBroker.Instance().SendMessage(new UpdateEnergyTimeEvent(this.myTime));
                this.myTime = 0;
            }
        }
        
        public object CaptureState()
            => this.timeRemaining;

        public void RestoreState(object state)
            => this.timeRemaining = (float) state;
    }
}