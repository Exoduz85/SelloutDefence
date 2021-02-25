using System;
using System.Collections;
using Core;
using EventBrokerFolder;
using UnityEngine;

namespace Player.Energy {
    public class RetroActiveEnergyReward : MonoBehaviour {
        public IEnumerator RetroActiveRefillAsync(float remainingTime, float refillCd) {
            yield return LoginData.GetTime();
            var lastLogin = LoginData.LastLogin;
            var now = LoginData.Now;
            var diff = now - lastLogin;
            var days = DaysOffline(diff);
            diff = MoreThanOneDayOffline(diff, now, lastLogin);

            var totalSeconds = (days + diff.Hours) * 60 * 60 + diff.Minutes * 60 + diff.Seconds;
            var energyToGive = (int) (totalSeconds / refillCd);
            CalculateRemainingTime(remainingTime, energyToGive, totalSeconds);
            EventBroker.Instance().SendMessage(new PlayerEnergyAwardEvent(energyToGive));
        }

        void CalculateRemainingTime(float remainingTime, float energyToGive, float totSeconds) {
            if (energyToGive >= 10) {
                this.RemainingTime = 300;
                return;
            }

            var remaining = Mathf.Abs(totSeconds - remainingTime);
            var totEnergyTime = energyToGive * 300;
            var tot3 = totEnergyTime - remaining;
            this.RemainingTime = tot3;
        }

        public float RemainingTime { get; private set; }

        static int DaysOffline(TimeSpan diff) {
            return diff.Days * 24;
        }

        static TimeSpan MoreThanOneDayOffline(TimeSpan diff, DateTime now, DateTime lastLogin) {
            if (Mathf.Abs(diff.Days) > 0) {
                var newNow = now.AddDays(-Mathf.Abs(diff.Days));
                diff = lastLogin.TimeOfDay - newNow.TimeOfDay;
            }

            return diff;
        }
    }
}