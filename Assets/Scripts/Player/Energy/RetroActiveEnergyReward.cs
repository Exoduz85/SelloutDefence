using System;
using System.Collections;
using Core;
using EventBrokerFolder;
using UnityEngine;

namespace Player.Energy {
    public class RetroActiveEnergyReward : MonoBehaviour {
        [SerializeField]
        RefillTime refill;


        void Update() {
            if (Input.GetKeyDown(KeyCode.T)) {
                StartCoroutine(TimeSinceLastLogin());
            }
        }

        IEnumerator TimeSinceLastLogin() {
            yield return LoginData.GetTime();
            var lastLogin = LoginData.LastLogin;
            var now = LoginData.Now;
            var diff = now - lastLogin;

            diff = MoreThanOneDayOffline(diff, now, lastLogin);

            var energyToGive = (diff.Hours * 60 * 60 + diff.Minutes * 60 + diff.Seconds) / this.refill.energyFillCd;

            EventBroker.Instance().SendMessage(new UpdatePlayerEnergyEvent((int) energyToGive));
            print($"Energy to give: {energyToGive}");

            print(Mathf.Abs(diff.Days));
            print($"{diff.Hours}:{diff.Minutes}:{diff.Seconds}");
            print(diff.Hours * 60 * 60 + diff.Minutes * 60 + diff.Seconds);
        }

        static TimeSpan MoreThanOneDayOffline(TimeSpan diff, DateTime now, DateTime lastLogin) {
            if (Mathf.Abs(diff.Days) > 0) {
                var newNow = now.AddDays(-Mathf.Abs(diff.Days));
                diff = newNow.TimeOfDay - lastLogin.TimeOfDay;
            }

            return diff;
        }
    }
}