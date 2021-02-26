using EventBrokerFolder;
using Saving;
using UnityEngine;

namespace Player.Energy {
    public class RefillTime : MonoBehaviour, ISavable {
        float myTime;
        float timeRemaining;
        public float energyFillCd = 120;


        void Start() {
            this.timeRemaining = this.energyFillCd;
            EventBroker.Instance().SubscribeMessage<EventGetRetroActiveData>(UpdateRetroActiveData);
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
            EventBroker.Instance().SendMessage(new EventEnergyAward(1));
            this.timeRemaining = this.energyFillCd;
        }

        void UpdateTimer() {
            this.timeRemaining--;
            EventBroker.Instance().SendMessage(new EventUpdateEnergyTime(this.timeRemaining));
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
        }

        void UpdateRetroActiveData(EventGetRetroActiveData totSeconds) {
            var energyToGive = (int) (totSeconds.TotalSeconds / this.energyFillCd);
            EventBroker.Instance().SendMessage(new EventEnergyAward(energyToGive));
            CalculateRemainingTime(energyToGive, totSeconds.TotalSeconds);
        }

        void CalculateRemainingTime(float energyToGive, float totSeconds) {
            if (energyToGive >= 10) {
                this.timeRemaining = this.energyFillCd;
                return;
            }

            var remaining = Mathf.Abs(totSeconds - this.timeRemaining);
            var totEnergyTime = energyToGive * this.energyFillCd;
            var tot = remaining;
            if (totEnergyTime > 0) {
                tot = Mathf.Abs(remaining - totEnergyTime);
            }

            this.timeRemaining = tot;
        }
    }
}