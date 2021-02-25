using System.Collections;
using EventBrokerFolder;
using Saving;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Energy {
    public class RefillTime : MonoBehaviour, ISavable {
        float myTime;
        float timeRemaining;
        public float energyFillCd = 120;


        void Start() {
            this.timeRemaining = this.energyFillCd;
        }

        void Update() {
            this.myTime += Time.deltaTime;
            if (CanUpdateTimer()) {
                UpdateTimer();
                if (CanAwardEnergy()) {
                    AwardEnergy();
                }
            }
        }

        void AwardEnergy() {
            EventBroker.Instance().SendMessage(new PlayerEnergyAwardEvent(1));
            this.timeRemaining = this.energyFillCd;
        }

        void UpdateTimer() {
            this.timeRemaining--;
            EventBroker.Instance().SendMessage(new UpdateEnergyTimeEvent(this.timeRemaining));
            this.myTime = 0;
        }

        bool CanUpdateTimer() {
            return this.myTime >= 1;
        }

        bool CanAwardEnergy() {
            return this.timeRemaining <= 0;
        }

        public object CaptureState()
            => this.timeRemaining;

        public void RestoreState(object state) {
            this.timeRemaining = (float) state;
            StartCoroutine(UpdateRemainingTime(this.timeRemaining));
        }

        IEnumerator UpdateRemainingTime(float remainingTimer) {
            var retroEnergy = FindObjectOfType<RetroActiveEnergyReward>();
            yield return retroEnergy.RetroActiveRefillAsync(remainingTimer, this.energyFillCd);
            this.timeRemaining = retroEnergy.RemainingTime;
        }
    }
}