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
            print($"Last login: {lastLogin} Now: {now}");
            var days = DaysOffline(diff);
            diff = MoreThanOneDayOffline(diff, now, lastLogin);

            var totalSeconds = (days + diff.Hours) * 60 * 60 + diff.Minutes * 60 + diff.Seconds;
            var energyToGive = (int) (totalSeconds / refillCd);
            print($"tot seconds {totalSeconds} {energyToGive}");
            CalculateRemainingTime(remainingTime, energyToGive, totalSeconds);
            EventBroker.Instance().SendMessage(new PlayerEnergyAwardEvent(energyToGive));
        }

        void CalculateRemainingTime(float remainingTime, float energyToGive, float totSeconds) {
            if (energyToGive >= 10) {
                this.RemainingTime = 300;
                return;
            }
            // passed time: 06:43

            //remaining time = 60 sec
            var tot1 = totSeconds - remainingTime;

            //passed time: 05:43
            var tot2 = energyToGive * 300;

            var tot3 = tot2 - tot1;
            //passed time: 00:43
            var tmp = 300 - tot3;
            this.RemainingTime = tmp;
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