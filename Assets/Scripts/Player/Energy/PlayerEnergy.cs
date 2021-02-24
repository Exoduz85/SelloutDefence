using System;
using System.Collections;
using Core;
using EventBrokerFolder;
using Saving;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Energy {
    //TODO should persist through scenes?
    public class PlayerEnergy : MonoBehaviour, ISavable {
        public float energyFillCd = 120;
        float timeRemaining;

        int RemainingEnergy { get; set; }

        public Text energyText;

        float myTime;

        object[] dataToSave = new object[2];
        int minues;
        int seconds;

        void Start() {
            this.timeRemaining = this.energyFillCd;
            print(this.timeRemaining);
            EventBroker.Instance().SubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergy);
        }

        void Update() {
            this.myTime += Time.deltaTime;
            if (this.myTime >= 1) {
                this.timeRemaining--;
                UpdateTimeText();
                this.myTime = 0;
            }

            if (Input.GetKeyDown(KeyCode.T)) {
                StartCoroutine(TimeSinceLastLogin());
            }
        }

        IEnumerator TimeSinceLastLogin() {
            yield return LoginData.GetTime();
            var lastLogin = LoginData.LastLogin;
            var now = LoginData.Now;
            var diff = now - lastLogin;

            if (Mathf.Abs(diff.Days) > 0) {
                var newNow = now.AddDays(-Mathf.Abs(diff.Days));
                diff = newNow.TimeOfDay - lastLogin.TimeOfDay;
            }

            var energyToGive = (diff.Hours * 60 * 60 + diff.Minutes * 60 + diff.Seconds) / this.energyFillCd;

            print($"Energy to give: {energyToGive}");

            print(Mathf.Abs(diff.Days));
            print($"{diff.Hours}:{diff.Minutes}:{diff.Seconds}" );
            print(diff.Hours * 60 * 60 + diff.Minutes * 60 + diff.Seconds);
        }

        void UpdateEnergy(UpdatePlayerEnergyEvent energy) {
            this.RemainingEnergy += energy.EnergyToUpdate;
            Debug.Log($"Remaining energy: {this.RemainingEnergy}");
        }

        void UpdateTimeText() {
            this.energyText.text = $"{Minutes()}:{Seconds()}";
        }

        int Minutes() {
            return Mathf.FloorToInt(this.timeRemaining / 60);
        }

        int Seconds() {
            return Mathf.FloorToInt(this.timeRemaining % 60);
        }

        public object CaptureState() {
            this.dataToSave[0] = this.RemainingEnergy;
            this.dataToSave[1] = this.timeRemaining;
            return this.dataToSave;
        }


        public void RestoreState(object state) {
            this.dataToSave = (object[]) state;
            this.RemainingEnergy = (int) this.dataToSave[0];
            this.timeRemaining = (float) this.dataToSave[1];

            StartCoroutine(TimeSinceLastLogin());
        }
    }
}