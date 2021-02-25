using System;
using System.Collections;
using Core;
using EventBrokerFolder;
using UnityEngine;

namespace Player {
    public class RetroActiveData : MonoBehaviour {
        void Update() {
            if (Input.GetKeyDown(KeyCode.L))
                StartCoroutine(RetroActiveRefillAsync());
        }

        IEnumerator RetroActiveRefillAsync() {
            yield return LoginData.GetTime();
            var lastLogin = LoginData.LastLogin;
            var now = LoginData.Now;
            var diffSinceLastLogin = now - lastLogin;
            var daysToHours = DaysOffline(diffSinceLastLogin);
            diffSinceLastLogin = MoreThanOneDayOffline(diffSinceLastLogin, now, lastLogin);

            var totalSeconds = (daysToHours + diffSinceLastLogin.Hours) * 60 * 60 + diffSinceLastLogin.Minutes * 60 + diffSinceLastLogin.Seconds;
            EventBroker.Instance().SendMessage(new EventGetRetroActiveData(totalSeconds));
        }

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